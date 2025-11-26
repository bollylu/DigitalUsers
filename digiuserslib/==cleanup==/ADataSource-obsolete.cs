namespace digiuserslib;

public abstract class ADataSource_obsolete : ILoggable, IDataSource {

  public ILogger Logger { get; set; } = new TTraceLogger();

  protected readonly List<ITable> _Tables = [];

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  protected ADataSource_obsolete() { }
  protected ADataSource_obsolete(ILogger logger) {
    Logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public abstract IContact? GetContact(TKeyId id);
  public abstract IEnumerable<IContact> GetContacts();
  public abstract IContact? GetContactByPhoneNumber(IPhoneNumber phoneNumber);
  public abstract IContact? GetContactByEmail(IMailAddress mailAddress);

  public abstract ILocation? GetLocation(string id);
  public abstract IEnumerable<ILocation> GetLocations();
  public abstract IEnumerable<ILocation> GetLocationsByPerson(string idPerson);
  public abstract IPhoneNumber? GetPhoneNumber(string id);
  public abstract IEnumerable<IPhoneNumber> GetPhoneNumbers();
  public abstract IEnumerable<IPhoneNumber> GetPhoneNumbersByPerson(string idPerson);
  public abstract IMailAddress? GetMailAddress(string id);
  public abstract IEnumerable<IMailAddress> GetMailAddresses();
  public abstract IEnumerable<IMailAddress> GetMailAddressesByPerson(string idPerson);

  public abstract IEnumerable<IContact> GetContactsByLocation(ILocation location);
  public abstract IDepartment? GetDepartment(string departmentId);
  public abstract IContact? GetHeadOfDepartment(string departmentId);
  public abstract IEnumerable<IContact> GetDepartmentMembers(string departmentId);

  public abstract bool Open();
  public abstract bool Close();
  public abstract bool Read();
  public abstract bool Save();

    
}
