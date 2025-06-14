
using BLTools.Diagnostic.Logging;

namespace digiuserslib;

public class TDataSourceWeb : ALoggable, IDataSource {

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

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDataSourceWeb() { }

  public TDataSourceWeb(Uri dataSourceUri) {
    DataSourceUri = dataSourceUri;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public async ValueTask<bool> Open() {

    try {
      CancellationToken cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
      LastResponse = await _HttpClient.GetAsync("probe", cancellationToken).ConfigureAwait(false);

      return LastResponse.IsSuccessStatusCode;

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to probe server", ex);
      return false;
    }

  }

  public ValueTask<bool> Close() {
    throw new NotImplementedException();
  }

  public ValueTask<bool> Read() {
    throw new NotImplementedException();
  }

  public ValueTask<bool> Save() {
    throw new NotImplementedException();
  }

  public IEnumerable<IPerson> GetPeople() {
    throw new NotImplementedException();
  }

  public IPerson? GetPerson(string id) {
    throw new NotImplementedException();
  }

  public IEnumerable<IPerson> GetPeopleForDepartment(string department) {
    throw new NotImplementedException();
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
