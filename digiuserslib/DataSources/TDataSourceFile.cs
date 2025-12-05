using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools;

using digiuserslib.Json;

namespace digiuserslib;

public class TDataSourceFile : ILoggable, IDataSourceDMOAsync, IDataSourceAsync {

  public const string DEFAULT_LOCATION = ".";

  public ILogger Logger { get; set; } = new TTraceLogger() { Name = nameof(TDataSourceFile) };

  public string DataFileLocation { get; set; } = DEFAULT_LOCATION;

  protected readonly List<ITable> _Tables = [];

  private TTableContactsFile ContactsTable => (TTableContactsFile?)_Tables.FirstOrDefault(t => t is TTableContactsFile) ?? throw new ApplicationException("TableContactsFile is missing");
  private TTablePhoneNumbersMemory? PhoneNumbersTable => (TTablePhoneNumbersMemory?)_Tables.FirstOrDefault(t => t is TTablePhoneNumbersMemory);
  private TTableLocationsFile? LocationsTable => (TTableLocationsFile?)_Tables.FirstOrDefault(t => t is TTableLocationsFile);
  private TTableMailAddressesMemory? PhoneMailAddressesTable => (TTableMailAddressesMemory?)_Tables.FirstOrDefault(t => t is TTableMailAddressesMemory);
  private TTableDepartmentsMemory? PhoneDepartmentTable => (TTableDepartmentsMemory?)_Tables.FirstOrDefault(t => t is TTableDepartmentsMemory);

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDataSourceFile(string dataFileLocation = DEFAULT_LOCATION) {
    DataFileLocation = dataFileLocation;
    try {
      if (!Directory.Exists(DataFileLocation)) {
        Directory.CreateDirectory(DataFileLocation);
      }
    } catch (Exception ex) {
      throw new ApplicationException($"Unable to create directory {DataFileLocation.WithQuotes()}", ex);
    }
    _Tables.Add(new TTableLocationsFile(Path.Combine(DataFileLocation, "locations.json")));
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  #region --- Basic I/O -------------------------------------------------------
  public async ValueTask<bool> OpenAsync() {
    foreach (ITableHandlingAsync TableItem in _Tables) {
      if (!await TableItem.OpenAsync().ConfigureAwait(false)) {
        Logger.LogError($"Unable to open table {TableItem.Name.WithQuotes()}");
        return false;
      }
    }
    return true;
  }

  public async ValueTask<bool> CloseAsync() {
    foreach (ITableHandlingAsync TableItem in _Tables) {
      if (!await TableItem.CloseAsync().ConfigureAwait(false)) {
        Logger.LogError($"Unable to close table {TableItem.Name.WithQuotes()}");
        return false;
      }
    }
    return true;
  }

  #endregion ------------------------------------------------------------------

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
}
