using BLTools.Diagnostic.Logging;

namespace digiuserslib;

[System.Runtime.Versioning.RequiresPreviewFeatures]
public abstract class ADataSource : ALoggable, IDataSource {

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  protected ADataSource() {
    Logger = new TConsoleLogger();
  }
  protected ADataSource(ILogger logger) {
    Logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public abstract Task<IPerson?> GetPersonAsync(TKeyId id);
  public abstract IAsyncEnumerable<IPerson> GetPeopleAsync();
  public abstract Task<IPerson?> GetPersonByPhoneNumberAsync(IPhoneNumber phoneNumber);
  public abstract Task<IPerson?> GetPersonByEmailAsync(IMailAddress mailAddress);

  public abstract Task<ILocation?> GetLocationAsync(string id);
  public abstract IAsyncEnumerable<ILocation> GetLocationsAsync();
  public abstract IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(string idPerson);
  public abstract Task<IPhoneNumber?> GetPhoneNumberAsync(string id);
  public abstract IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync();
  public abstract IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(string idPerson);
  public abstract Task<IMailAddress?> GetMailAddressAsync(string id);
  public abstract IAsyncEnumerable<IMailAddress> GetMailAddressesAsync();
  public abstract IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(string idPerson);

  public abstract IAsyncEnumerable<IPerson> GetPeopleByLocationAsync(ILocation location);
  public abstract Task<IDepartment?> GetDepartmentAsync(string departmentId);
  public abstract Task<IPerson?> GetHeadOfDepartmentAsync(string departmentId);
  public abstract IAsyncEnumerable<IPerson> GetDepartmentMembersAsync(string departmentId);

  public abstract ValueTask<bool> OpenAsync();
  public abstract ValueTask<bool> CloseAsync();
  public abstract ValueTask<bool> ReadAsync();
  public abstract ValueTask<bool> SaveAsync();
  public abstract bool Open();
  public abstract bool Close();
  public abstract bool Read();
  public abstract bool Save();
}
