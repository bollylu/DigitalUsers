using System.Transactions;

using BLTools;

using digiuserslib.Model;

namespace digiuserslib {
  public class TDataSourceMemory : ADataSourceDMOAsync, IDataSourceAsync {

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TDataSourceMemory() {
      _Initialize();
    }

    private TTableContactsMemory ContactsTable => (TTableContactsMemory?)_Tables.FirstOrDefault(t => t is TTableContactsMemory) ?? throw new ApplicationException("TableContactMemory is missing");
    private TTablePhoneNumbersMemory PhoneNumbersTable => (TTablePhoneNumbersMemory?)_Tables.FirstOrDefault(t => t is TTablePhoneNumbersMemory) ?? throw new ApplicationException("TablePhoneNumbersMemory is missing");
    private TTableLocationsMemory LocationsTable => (TTableLocationsMemory?)_Tables.FirstOrDefault(t => t is TTableLocationsMemory) ?? throw new ApplicationException("TableLocationsMemory is missing");
    private TTableMailAddressesMemory MailAddressesTable => (TTableMailAddressesMemory?)_Tables.FirstOrDefault(t => t is TTableMailAddressesMemory) ?? throw new ApplicationException("TableMailAddressesMemory is missing");
    private TTableDepartmentsMemory DepartmentsTable => (TTableDepartmentsMemory?)_Tables.FirstOrDefault(t => t is TTableDepartmentsMemory) ?? throw new ApplicationException("TableDepartmentMemory is missing");

    private void _Initialize() {
      _Tables.Add(new TTableContactsMemory());
      _Tables.Add(new TTablePhoneNumbersMemory());
      _Tables.Add(new TTableLocationsMemory());
      _Tables.Add(new TTableMailAddressesMemory());
      _Tables.Add(new TTableDepartmentsMemory());
    }
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    #region --- I/O -------------------------------------
    public override async ValueTask<bool> OpenAsync() {
      foreach (ITableHandlingAsync TableItem in _Tables) {
        if (!await TableItem.OpenAsync()) {
          Logger.LogError($"Unable to open table {TableItem.Name.WithQuotes()}");
          return false;
        }
      }
      return true;
    }

    public override async ValueTask<bool> CloseAsync() {
      foreach (ITableHandlingAsync TableItem in _Tables) {
        if (!await TableItem.CloseAsync()) {
          Logger.LogError($"Unable to close table {TableItem.Name.WithQuotes()}");
          return false;
        }
      }
      return true;
    }
    #endregion --- I/O -----------------------------------------

    public Task<IContact?> GetContactAsync(IKeyId id) {
      IContact? Result = ContactsTable.Get(id);
      if (Result is null) {
        Logger.LogWarning($"Contact with Id {id} not found.");
      }
      return Task.FromResult(Result);
    }

    public ValueTask<bool> DeleteContactAsync(IKeyId id) {
      return ValueTask.FromResult(ContactsTable.Delete(id));
    }

    public async IAsyncEnumerable<IContact> GetContactsAsync() {
      await Task.Yield();
      foreach (IContact ContactItem in ContactsTable.GetAll()) {
        yield return ContactItem;
      }
    }

    public Task<IContact?> GetContactByPhoneNumberAsync(string phoneNumber) {
      IContact? Result = ContactsTable.GetAll()
        .Where(x => x.PhoneNumbers
                 .Any(p => p.FullPhoneNumber.Contains(phoneNumber))
              ).FirstOrDefault();
      if (Result is null) {
        Logger.LogWarning($"Contact with phone number {phoneNumber.WithQuotes()} not found.");
      }
      return Task.FromResult(Result);
    }

    public Task<IContact?> CreateContactAsync(IContactBasic contact) {
      return Task.FromResult(ContactsTable.Create(contact));
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

    public IAsyncEnumerable<IContact> GetContactsByLocationAsync(string location) {
      throw new NotImplementedException();
    }

    #region --- Locations -----------------------------------------------------
    public Task<ILocation?> GetLocationAsync(IKeyId id) {
      ILocation? Result = LocationsTable.Get(id);
      if (Result is null) {
        Logger.LogWarning($"Location with Id {id.Value.WithQuotes()} not found.");
      }
      return Task.FromResult(Result);
    }

    public async IAsyncEnumerable<ILocation> GetLocationsAsync() {
      await Task.Yield();
      foreach (ILocation LocationItem in LocationsTable.GetAll()) {
        yield return LocationItem;
      }
    }

    public IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(IKeyId idPerson) {
      throw new NotImplementedException();
    }
    #endregion ----------------------------------------------------------------


    #region --- Phone numbers -------------------------------------------------
    public Task<IPhoneNumber?> GetPhoneNumberAsync(IKeyId id) {
      throw new NotImplementedException();
    }

    public async IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync() {
      await Task.Yield();
      foreach (IPhoneNumber PhoneNumberItem in PhoneNumbersTable.GetAll()) {
        yield return PhoneNumberItem;
      }
    }

    public IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(IKeyId idPerson) {
      throw new NotImplementedException();
    }

    public Task<IPhoneNumber?> CreatePhoneNumberAsync(IPhoneNumber phoneNumber) {
      if (phoneNumber.IsInvalid) {
        phoneNumber.Id.Value = phoneNumber.FullPhoneNumber;
      }
      IPhoneNumber? AlreadyExistingPhoneNumber = PhoneNumbersTable.GetAll()
        .FirstOrDefault(pn => pn.FullPhoneNumber == phoneNumber.FullPhoneNumber);
      if (AlreadyExistingPhoneNumber is not null) {
        return Task.FromResult<IPhoneNumber?>(null);
      }
      return Task.FromResult<IPhoneNumber?>(PhoneNumbersTable.Create(phoneNumber));
    }
    #endregion ----------------------------------------------------------------

    #region --- Mail addresses ------------------------------------------------
    public Task<IMailAddress?> GetMailAddressAsync(IKeyId id) {
      throw new NotImplementedException();
    }

    public async IAsyncEnumerable<IMailAddress> GetMailAddressesAsync() {
      await Task.Yield();
      foreach (IMailAddress MailAddressItem in MailAddressesTable.GetAll()) {
        yield return MailAddressItem;
      }
    }

    public IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(IKeyId idPerson) {
      throw new NotImplementedException();
    }

    public Task<IContact?> GetContactByEmailAsync(string mailAddress) {
      throw new NotImplementedException();
    }
    #endregion ----------------------------------------------------------------

    #region --- Departments ---------------------------------------------------
    public Task<IDepartment?> GetDepartmentAsync(IKeyId departmentId) {
      throw new NotImplementedException();
    }

    public Task<IContact?> GetHeadOfDepartmentAsync(string departmentId) {
      throw new NotImplementedException();
    }

    public IAsyncEnumerable<IContact> GetDepartmentMembersAsync(IKeyId departmentId) {
      throw new NotImplementedException();
    }

    public async IAsyncEnumerable<IDepartment> GetDepartmentsAsync() {
      await Task.Yield();
      foreach (IDepartment DepartmentItem in DepartmentsTable.GetAll()) {
        yield return DepartmentItem;
      }
    }

    public IAsyncEnumerable<IContact> GetDepartmentMembersAsync(string departmentId) {
      throw new NotImplementedException();
    }


    #endregion ----------------------------------------------------------------

    #region --- Pictures ------------------------------------------------------
    public Task<IPicture?> GetPictureAsync(IKeyId id) {
      throw new NotImplementedException();
    }

    public IAsyncEnumerable<IPicture> GetPicturesAsync() {
      throw new NotImplementedException();
    }

    public IAsyncEnumerable<IPicture> GetPicturesByPersonAsync(IKeyId idPerson) {
      throw new NotImplementedException();
    }
    #endregion ----------------------------------------------------------------


  }
}
