namespace digiuserslib;

public interface IDataSourceAsync {

  #region --- Locations --------------------------------------------
  Task<ILocation?> GetLocationAsync(string id);
  IAsyncEnumerable<ILocation> GetLocationsAsync();
  IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(string idPerson);
  #endregion --- Locations -----------------------------------------

  #region --- Phone numbers --------------------------------------------
  Task<IPhoneNumber?> GetPhoneNumberAsync(string id);
  IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync();
  IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(string idPerson);
  #endregion --- Phone numbers -----------------------------------------

  #region --- Mail addresses --------------------------------------------
  Task<IMailAddress?> GetMailAddressAsync(string id);
  IAsyncEnumerable<IMailAddress> GetMailAddressesAsync();
  IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(string idPerson);
  #endregion --- Mail addresses -----------------------------------------

  #region --- Contact --------------------------------------------
  Task<IContact?> GetContactAsync(TKeyId id);
  IAsyncEnumerable<IContact> GetContactsAsync();
  Task<IContact?> GetContactByPhoneNumberAsync(string phoneNumber);
  Task<IContact?> GetContactByEmailAsync(string mailAddress);
  IAsyncEnumerable<IContact> GetContactsByLocationAsync(string location);
  #endregion --- Contact -----------------------------------------

  #region --- Departments --------------------------------------------
  Task<IDepartment?> GetDepartmentAsync(string departmentId);
  IAsyncEnumerable<IDepartment> GetDepartmentsAsync();
  Task<IContact?> GetHeadOfDepartmentAsync(string departmentId);
  IAsyncEnumerable<IContact> GetDepartmentMembersAsync(string departmentId);
  #endregion --- Departments -----------------------------------------
}
