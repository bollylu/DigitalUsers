using BLTools;
using BLTools.Diagnostic.Logging;

namespace digiuserslib;

public abstract class ADataSource : ALoggable, IDataSource {

  protected readonly List<ITable> _Tables = [];

  public ATable<ILocation> TableLocation =>
    _Tables.OfType<ATable<ILocation>>().SingleOrDefault() ??
    throw new InvalidOperationException("TableLocation is not initialized.");

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  protected ADataSource() {
    Logger = new TConsoleLogger();
  }
  protected ADataSource(ILogger logger) {
    Logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  #region --- Data access --------------------------------------------
  public async Task<ILocation?> GetLocationAsync(string id) {
    return await TableLocation.GetAsync(id).ConfigureAwait(false);
  }
  public async IAsyncEnumerable<ILocation> GetLocationsAsync() {
    await foreach (ILocation LocationItem in TableLocation.GetAllAsync().ConfigureAwait(false)) {
      yield return LocationItem;
    }
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

  public Task<IPerson?> GetPersonAsync(string id) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IPerson> GetPeopleAsync() {
    throw new NotImplementedException();
  }

  public Task<IPerson?> GetPersonByPhoneNumberAsync(IPhoneNumber phoneNumber) {
    throw new NotImplementedException();
  }

  public Task<IPerson?> GetPersonByEmailAsync(IMailAddress mailAddress) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IPerson> GetPeopleByLocationAsync(ILocation location) {
    throw new NotImplementedException();
  }

  public Task<IDepartment?> GetDepartmentAsync(string departmentId) {
    throw new NotImplementedException();
  }

  public Task<IPerson?> GetHeadOfDepartmentAsync(string departmentId) {
    throw new NotImplementedException();
  }

  public IAsyncEnumerable<IPerson> GetDepartmentMembersAsync(string departmentId) {
    throw new NotImplementedException();
  }

  #endregion --- Data access -----------------------------------------

  #region --- I/O --------------------------------------------
  public async ValueTask<bool> Open() {
    foreach (ITable TableItem in _Tables) {
      if (!await TableItem.Open().ConfigureAwait(false)) {
        Logger.LogError($"Unable to open table {TableItem.Name.WithQuotes()}");
        return false;
      }
    }
    return true;
  }

  public async ValueTask<bool> Close() {
    foreach (ITable TableItem in _Tables) {
      if (!await TableItem.Close().ConfigureAwait(false)) {
        Logger.LogError($"Unable to close table {TableItem.Name.WithQuotes()}");
        return false;
      }
    }
    return true;
  }

  public async ValueTask<bool> Read() {
    foreach (ITable TableItem in _Tables) {
      if (!await TableItem.Read().ConfigureAwait(false)) {
        Logger.LogError($"Unable to read table {TableItem.Name.WithQuotes()}");
        return false;
      }
    }
    return true;
  }

  public async ValueTask<bool> Save() {
    foreach (ITable TableItem in _Tables) {
      if (!await TableItem.Save().ConfigureAwait(false)) {
        Logger.LogError($"Unable to save table {TableItem.Name.WithQuotes()}");
        return false;
      }
    }
    return true;
  }
  #endregion --- I/O -----------------------------------------
}
