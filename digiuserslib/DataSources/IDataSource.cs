namespace digiuserslib;

public interface IDataSource {

  #region --- I/O --------------------------------------------
  ValueTask<bool> Open();
  ValueTask<bool> Close();

  ValueTask<bool> Read();
  ValueTask<bool> Save();
  #endregion --- I/O -----------------------------------------

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

  #region --- People --------------------------------------------
  Task<IPerson?> GetPersonAsync(string id);
  IAsyncEnumerable<IPerson> GetPeopleAsync();
  Task<IPerson?> GetPersonByPhoneNumberAsync(IPhoneNumber phoneNumber);
  Task<IPerson?> GetPersonByEmailAsync(IMailAddress mailAddress);
  IAsyncEnumerable<IPerson> GetPeopleByLocationAsync(ILocation location);
  #endregion --- People -----------------------------------------

  #region --- Departments --------------------------------------------
  Task<IDepartment?> GetDepartmentAsync(string departmentId);
  Task<IPerson?> GetHeadOfDepartmentAsync(string departmentId);
  IAsyncEnumerable<IPerson> GetDepartmentMembersAsync(string departmentId);
  #endregion --- Departments -----------------------------------------

}
