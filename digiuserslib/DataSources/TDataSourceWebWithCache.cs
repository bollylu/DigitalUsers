
using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools.Diagnostic.Logging;

using digiuserslib.Json;

namespace digiuserslib;

public class TDataSourceWebWithCache : ALoggable, IDataSource {

  public Uri? DataSourceUri {
    get => _dataSourceUri;
    set {
      _dataSourceUri = value;
      _HttpClient.BaseAddress = value;
    }
  }
  private Uri? _dataSourceUri;

  private readonly HttpClient _HttpClient = new HttpClient();
  public HttpResponseMessage? LastResponse { get; private set; }

  private readonly List<IPerson> _People = new List<IPerson>();

  private readonly JsonSerializerOptions _JsonOptions = new() {
    WriteIndented = true,
    Converters = {
      new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
      new TAgentJsonConverter()
    }
  };

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDataSourceWebWithCache() { }

  public TDataSourceWebWithCache(string dataSourceUri) {
    DataSourceUri = new Uri(dataSourceUri);
  }

  public TDataSourceWebWithCache(Uri dataSourceUri) {
    DataSourceUri = dataSourceUri;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public async ValueTask<bool> Open() {

    try {
      CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
      LastResponse = await _HttpClient.GetAsync("probe", HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

      return LastResponse.IsSuccessStatusCode;

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to probe server", ex);
      return false;
    }

  }

  public ValueTask<bool> Close() {
    return ValueTask.FromResult(true);
  }

  public async ValueTask<bool> Read() {
    try {
      CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
      LastResponse = await _HttpClient.GetAsync("getall", cancellationToken).ConfigureAwait(false);

      if (LastResponse.IsSuccessStatusCode) {
        string DataFileContent = await LastResponse.Content.ReadAsStringAsync();
        Logger.LogDebugBox("Content", DataFileContent);
        _People.Clear();
        _People.AddRange(JsonSerializer.Deserialize<List<TAgent>>(DataFileContent, _JsonOptions) ?? []);
        return true;
      } else {
        return false;
      }

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to read data from server", ex);
      return false;
    }
  }

  public ValueTask<bool> Save() {
    throw new NotImplementedException();
  }

  public IEnumerable<IPerson> GetPeople() {
    return _People;
  }

  public IPerson? GetPerson(string id) {
    return _People.FirstOrDefault(p => p.Id == id);
  }

  public IEnumerable<IPerson> GetPeopleForDepartment(string department) {
    return _People.Where(p => p.Department.Contains(department, StringComparison.CurrentCultureIgnoreCase));
  }

  public IPerson? GetPersonForPhoneNumber(IPhoneNumber phoneNumber) {
    throw new NotImplementedException();
  }

  public IPerson? GetPersonForEmail(IMailAddress mailAddress) {
    throw new NotImplementedException();
  }

  public IEnumerable<IPerson> GetPeopleForLocation(ILocation location) {
    throw new NotImplementedException();
  }
}
