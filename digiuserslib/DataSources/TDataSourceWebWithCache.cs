
using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools;
using BLTools.Diagnostic.Logging;

using digiuserslib.DataSources;
using digiuserslib.Json;

namespace digiuserslib;

public class TDataSourceWebWithCache : ADataSourceWithCache {

  public Uri? DataSourceUri {
    get => _dataSourceUri;
    set {
      _dataSourceUri = value;
      _HttpClient.BaseAddress = value;
    }
  }
  private Uri? _dataSourceUri;

  private readonly HttpClient _HttpClient = new();
  public HttpResponseMessage? LastResponse { get; private set; }

  private readonly JsonSerializerOptions _JsonOptions = new() {
    WriteIndented = true,
    Converters = {
      new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
      new TAgentJsonConverter()
    },
    IndentSize = 2,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
  };

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDataSourceWebWithCache() {
  }

  public TDataSourceWebWithCache(string dataSourceUri) : this() {
    DataSourceUri = new Uri(dataSourceUri);
  }

  public TDataSourceWebWithCache(Uri dataSourceUri) : this() {
    DataSourceUri = dataSourceUri;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  #region --- I/O --------------------------------------------
  public override async ValueTask<bool> Open() {

    try {
      CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
      LastResponse = await _HttpClient.GetAsync("probe", HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

      return LastResponse.IsSuccessStatusCode;

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to probe server", ex);
      return false;
    }

  }

  public override ValueTask<bool> Close() {
    return ValueTask.FromResult(true);
  }

  public override async ValueTask<bool> Read() {
    string DataFileContent = "(null)";
    try {
      CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
      string Response = await _HttpClient.GetStringAsync("getall", cancellationToken).ConfigureAwait(false);

      if (Response is not null && !Response.IsEmpty()) {
        LastResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        DataFileContent = Response;
        Logger.LogDebugBox("Content", DataFileContent);
        _People.Clear();
        _People.AddRange(JsonSerializer.Deserialize<List<TAgent>>(DataFileContent, _JsonOptions) ?? []);
        return true;
      } else {
        return false;
      }

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to read data from server", ex);
      Logger.LogDebugBox("Datafilecontent", DataFileContent);
      return false;
    }
  }

  public override ValueTask<bool> Save() {
    throw new NotImplementedException();
  }
  #endregion --- I/O -----------------------------------------

}
