
namespace digiuserslib;

public class TDataSourceWeb : ADataSourceDMOAsync, IDataSourceAsync {

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
  #endregion --- I/O -----------------------------------------

  public Task<ILocation?> GetLocationAsync(string id) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<ILocation> GetLocationsAsync() {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(string idPerson) {
    throw new NotImplementedException();
  }

  public Task<IPhoneNumber?> GetPhoneNumberAsync(string id) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync() {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(string idPerson) {
    throw new NotImplementedException();
  }

  public Task<IMailAddress?> GetMailAddressAsync(string id) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IMailAddress> GetMailAddressesAsync() {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(string idPerson) {
    throw new NotImplementedException();
  }

  public Task<IContact?> GetContactAsync(TKeyId id) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IContact> GetContactsAsync() {
    throw new NotImplementedException();
  }

  public Task<IContact?> GetContactByPhoneNumberAsync(string phoneNumber) {
    throw new NotImplementedException();
  }

  public Task<IContact?> GetContactByEmailAsync(string mailAddress) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IContact> GetContactsByLocationAsync(string location) {
    throw new NotImplementedException();
  }

  public Task<IDepartment?> GetDepartmentAsync(string departmentId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> GetHeadOfDepartmentAsync(string departmentId) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IContact> GetDepartmentMembersAsync(string departmentId) {
    throw new NotImplementedException();
  }

    public IAsyncEnumerable<IDepartment> GetDepartmentsAsync() {
        throw new NotImplementedException();
    }
}
