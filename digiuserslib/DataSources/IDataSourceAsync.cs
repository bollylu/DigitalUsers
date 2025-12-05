namespace digiuserslib;

public interface IDataSourceAsync {

  #region --- Locations --------------------------------------------
  Task<ILocation?> GetLocationAsync(IKeyId id);
  IAsyncEnumerable<ILocation> GetLocationsAsync();
  IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(IKeyId idPerson);
  #endregion --- Locations -----------------------------------------

  #region --- Phone numbers --------------------------------------------
  Task<IPhoneNumber?> GetPhoneNumberAsync(IKeyId id);
  IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync();
  IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(IKeyId idPerson);
  Task<IPhoneNumber?> CreatePhoneNumberAsync(IPhoneNumber phoneNumber);
  #endregion --- Phone numbers -----------------------------------------

  #region --- Mail addresses --------------------------------------------
  Task<IMailAddress?> GetMailAddressAsync(IKeyId id);
  IAsyncEnumerable<IMailAddress> GetMailAddressesAsync();
  IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(IKeyId idPerson);
  #endregion --- Mail addresses -----------------------------------------

  #region --- Contact --------------------------------------------
  Task<IContact?> GetContactAsync(IKeyId id);
  IAsyncEnumerable<IContact> GetContactsAsync();
  Task<IContact?> GetContactByPhoneNumberAsync(string phoneNumber);
  Task<IContact?> GetContactByEmailAsync(string mailAddress);
  IAsyncEnumerable<IContact> GetContactsByLocationAsync(string location);
  ValueTask<bool> DeleteContactAsync(IKeyId id);
  Task<IContact?> CreateContactAsync(IContactBasic contact);

  Task<IContact?> AddPhoneNumberToContactAsync(IKeyId contactId, IKeyId phoneNumberId);
  Task<IContact?> RemovePhoneNumberFromContactAsync(IKeyId contactId, IKeyId phoneNumberId);

  Task<IContact?> AddMailAddressToContactAsync(IKeyId contactId, IKeyId mailAddressId);
  Task<IContact?> RemoveMailAddressFromContactAsync(IKeyId contactId, IKeyId mailAddressId);

  Task<IContact?> AddLocationToContactAsync(IKeyId contactId, IKeyId locationId);
  Task<IContact?> RemoveLocationFromContactAsync(IKeyId contactId, IKeyId locationId);

  Task<IContact?> AddDepartmentToContactAsync(IKeyId contactId, IKeyId departmentId);
  Task<IContact?> RemoveDepartmentFromContactAsync(IKeyId contactId, IKeyId departmentId);

  Task<IContact?> AddPictureToContactAsync(IKeyId contactId, IKeyId pictureId);
  Task<IContact?> RemovePictureFromContactAsync(IKeyId contactId, IKeyId pictureId);

  #endregion --- Contact -----------------------------------------

  #region --- Departments --------------------------------------------
  Task<IDepartment?> GetDepartmentAsync(IKeyId departmentId);
  IAsyncEnumerable<IDepartment> GetDepartmentsAsync();
  Task<IContact?> GetHeadOfDepartmentAsync(string departmentId);
  IAsyncEnumerable<IContact> GetDepartmentMembersAsync(string departmentId);
  #endregion --- Departments -----------------------------------------

  #region --- Pictures --------------------------------------------------------
  Task<IPicture?> GetPictureAsync(IKeyId id);
  IAsyncEnumerable<IPicture> GetPicturesAsync();
  IAsyncEnumerable<IPicture> GetPicturesByPersonAsync(IKeyId idPerson);
  #endregion --- Mail addresses -----------------------------------------
}
