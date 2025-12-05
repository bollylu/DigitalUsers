


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


  #endregion --- I/O -----------------------------------------

  #region --- Actions ---------------------------------------------------------
  public override ValueTask<bool> CloseAsync() {
    return ValueTask.FromResult(true);
  }

  public Task<ILocation?> GetLocationAsync(IKeyId id) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<ILocation> GetLocationsAsync() {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(IKeyId idPerson) {
    throw new NotImplementedException();
  }

  public Task<IPhoneNumber?> GetPhoneNumberAsync(IKeyId id) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync() {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(IKeyId idPerson) {
    throw new NotImplementedException();
  }

  public Task<IMailAddress?> GetMailAddressAsync(IKeyId id) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IMailAddress> GetMailAddressesAsync() {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(IKeyId idPerson) {
    throw new NotImplementedException();
  }

  public Task<IContact?> GetContactAsync(IKeyId id) {
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

  public ValueTask<bool> DeleteContactAsync(IKeyId id) {
    throw new NotImplementedException();
  }

  public Task<IContact?> CreateContactAsync(IContactBasic contact) {
    throw new NotImplementedException();
  }

  public Task<IContact?> AddPhoneNumberToContactAsync(IKeyId contactId, IKeyId phoneNumberId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> RemovePhoneNumberFromContactAsync(IKeyId contactId, IKeyId phoneNumberId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> AddMailAddressToContactAsync(IKeyId contactId, IKeyId mailAddressId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> RemoveMailAddressFromContactAsync(IKeyId contactId, IKeyId mailAddressId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> AddLocationToContactAsync(IKeyId contactId, IKeyId locationId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> RemoveLocationFromContactAsync(IKeyId contactId, IKeyId locationId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> AddDepartmentToContactAsync(IKeyId contactId, IKeyId departmentId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> RemoveDepartmentFromContactAsync(IKeyId contactId, IKeyId departmentId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> AddPictureToContactAsync(IKeyId contactId, IKeyId pictureId) {
    throw new NotImplementedException();
  }

  public Task<IContact?> RemovePictureFromContactAsync(IKeyId contactId, IKeyId pictureId) {
    throw new NotImplementedException();
  }

  public Task<IDepartment?> GetDepartmentAsync(IKeyId departmentId) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IDepartment> GetDepartmentsAsync() {
    throw new NotImplementedException();
  }

  public Task<IContact?> GetHeadOfDepartmentAsync(string departmentId) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IContact> GetDepartmentMembersAsync(string departmentId) {
    throw new NotImplementedException();
  }

    public Task<IPicture?> GetPictureAsync(IKeyId id) {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<IPicture> GetPicturesAsync() {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<IPicture> GetPicturesByPersonAsync(IKeyId idPerson) {
        throw new NotImplementedException();
    }

    public Task<IPhoneNumber?> CreatePhoneNumberAsync(IPhoneNumber phoneNumber) {
        throw new NotImplementedException();
    }
    #endregion ------------------------------------------------------------------
}
