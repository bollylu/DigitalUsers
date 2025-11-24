using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools;

namespace digiuserslib;
public abstract class ATableWebMemory<T> : ATableMemory<T> where T : IRecord {

  public Uri? DataSourceUri {
    get => _dataSourceUri;
    set {
      _dataSourceUri = value;
      _HttpClient.BaseAddress = value;
    }
  }
  private Uri? _dataSourceUri;

  protected readonly HttpClient _HttpClient = new();
  public HttpResponseMessage? LastResponse { get; private set; }

  protected readonly JsonSerializerOptions _JsonOptions = new() {
    WriteIndented = true,
    Converters = {
      new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
    },
    IndentSize = 2,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
  };

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  protected ATableWebMemory() {
    Initialize();
  }
  protected ATableWebMemory(string dataSourceUri) : this() {
    DataSourceUri = new Uri(dataSourceUri);
  }
  protected ATableWebMemory(Uri dataSourceUri) : this() {
    DataSourceUri = dataSourceUri;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------


  protected override void Initialize() { }

  #region --- I/O --------------------------------------------
  public override async ValueTask<bool> OpenAsync() {

    try {
      CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
      LastResponse = await _HttpClient.GetAsync("probe", HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

      _Records.Clear(); // Clear existing records to ensure a fresh start
      return LastResponse.IsSuccessStatusCode;

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to probe server", ex);
      return false;
    }

  }

  public override async ValueTask<bool> CloseAsync() {
    if (IsDirty) { // If the data is dirty, we should save it before closing
      return await SaveAsync();
    }
    return true;
  }

  public override async ValueTask<bool> ReadAsync() {
    string DataResponse = "(null)";
    try {
      CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
      string Response = await _HttpClient.GetStringAsync("getall", cancellationToken).ConfigureAwait(false);

      if (Response is not null && !Response.IsEmpty()) {
        LastResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        DataResponse = Response;
        Logger.LogDebugBox("Content", DataResponse);
        _Records.Clear();
        _Records.AddRange(JsonSerializer.Deserialize<List<T>>(DataResponse, _JsonOptions) ?? []);
        IsDirty = false; // Reset dirty flag after reading
        return true;
      } else {
        return false;
      }

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to read data from server", ex);
      Logger.LogDebugBox("DataFileContent", DataResponse);
      return false;
    }
  }

  public override ValueTask<bool> SaveAsync() {
    throw new NotImplementedException("Save operation is not implemented for ATableWebMemory. Please implement it in derived classes.");
  }
  #endregion --- I/O -----------------------------------------
}
