namespace digiuserslib;

public abstract class ADataSourceAsync_obsolete : ILoggable, IDataSourceAsync {

  public ILogger Logger { get; set; } = new TTraceLogger();

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  protected ADataSourceAsync() {  }
  protected ADataSourceAsync(ILogger logger) {
    Logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public abstract Task<IContact?> GetContactAsync(TKeyId id);
  public abstract IAsyncEnumerable<IContact> GetContactsAsync();
  public abstract Task<IContact?> GetContactByPhoneNumberAsync(IPhoneNumber phoneNumber);
  public abstract Task<IContact?> GetContactByEmailAsync(IMailAddress mailAddress);

  public abstract Task<ILocation?> GetLocationAsync(string id);
  public abstract IAsyncEnumerable<ILocation> GetLocationsAsync();
  public abstract IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(string idPerson);
  public abstract Task<IPhoneNumber?> GetPhoneNumberAsync(string id);
  public abstract IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync();
  public abstract IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(string idPerson);
  public abstract Task<IMailAddress?> GetMailAddressAsync(string id);
  public abstract IAsyncEnumerable<IMailAddress> GetMailAddressesAsync();
  public abstract IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(string idPerson);

  public abstract IAsyncEnumerable<IContact> GetContactsByLocationAsync(ILocation location);
  public abstract Task<IDepartment?> GetDepartmentAsync(string departmentId);
  public abstract Task<IContact?> GetHeadOfDepartmentAsync(string departmentId);
  public abstract IAsyncEnumerable<IContact> GetDepartmentMembersAsync(string departmentId);

}
