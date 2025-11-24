
using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools;
using BLTools.Diagnostic.Logging;

using digiuserslib;
using digiuserslib.Json;

namespace digiuserslib;

public class TDataSourceWeb : ADataSource {

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
  public TDataSourceWeb() {
  }

  public TDataSourceWeb(string dataSourceUri) : this() {
    DataSourceUri = new Uri(dataSourceUri);
  }

  public TDataSourceWeb(Uri dataSourceUri) : this() {
    DataSourceUri = dataSourceUri;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  #region --- I/O --------------------------------------------
  public override async ValueTask<bool> OpenAsync() {

    try {
      CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
      LastResponse = await _HttpClient.GetAsync("probe", HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

      return LastResponse.IsSuccessStatusCode;

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to probe server", ex);
      return false;
    }

  }

  public override ValueTask<bool> CloseAsync() {
    return ValueTask.FromResult(true);
  }

  public override async ValueTask<bool> ReadAsync() {
    //string DataFileContent = "(null)";
    //try {
    //  CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
    //  string Response = await _HttpClient.GetStringAsync("getall", cancellationToken).ConfigureAwait(false);

    //  if (Response is not null && !Response.IsEmpty()) {
    //    LastResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
    //    DataFileContent = Response;
    //    Logger.LogDebugBox("Content", DataFileContent);
    //    _People.Clear();
    //    _People.AddRange(JsonSerializer.Deserialize<List<TAgent>>(DataFileContent, _JsonOptions) ?? []);
        return true;
      //} else {
      //  return false;
      //}

    //} catch (Exception ex) {
    //  Logger.LogErrorBox($"Unable to read data from server", ex);
    //  Logger.LogDebugBox("Datafilecontent", DataFileContent);
    //  return false;
    //}
  }

  public override ValueTask<bool> SaveAsync() {
    throw new NotImplementedException();
  }

    public override Task<IPerson?> GetPersonAsync(TKeyId id) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPerson> GetPeopleAsync() {
        throw new NotImplementedException();
    }

    public override Task<IPerson?> GetPersonByPhoneNumberAsync(IPhoneNumber phoneNumber) {
        throw new NotImplementedException();
    }

    public override Task<IPerson?> GetPersonByEmailAsync(IMailAddress mailAddress) {
        throw new NotImplementedException();
    }

    public override Task<ILocation?> GetLocationAsync(string id) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<ILocation> GetLocationsAsync() {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(string idPerson) {
        throw new NotImplementedException();
    }

    public override Task<IPhoneNumber?> GetPhoneNumberAsync(string id) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync() {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(string idPerson) {
        throw new NotImplementedException();
    }

    public override Task<IMailAddress?> GetMailAddressAsync(string id) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IMailAddress> GetMailAddressesAsync() {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(string idPerson) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPerson> GetPeopleByLocationAsync(ILocation location) {
        throw new NotImplementedException();
    }

    public override Task<IDepartment?> GetDepartmentAsync(string departmentId) {
        throw new NotImplementedException();
    }

    public override Task<IPerson?> GetHeadOfDepartmentAsync(string departmentId) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPerson> GetDepartmentMembersAsync(string departmentId) {
        throw new NotImplementedException();
    }

    public override bool Open() {
        throw new NotImplementedException();
    }

    public override bool Close() {
        throw new NotImplementedException();
    }

    public override bool Read() {
        throw new NotImplementedException();
    }

    public override bool Save() {
        throw new NotImplementedException();
    }
    #endregion --- I/O -----------------------------------------

}
