namespace digiuserslib;

public interface IDataSource_obsolete {

  #region --- I/O --------------------------------------------
  bool Open();
  bool Close();
  bool Read();
  bool Save();
  #endregion --- I/O -----------------------------------------

  #region --- Locations --------------------------------------------
  ILocation? GetLocation(string id);
  IEnumerable<ILocation> GetLocations();
  IEnumerable<ILocation> GetLocationsByPerson(string idPerson);
  #endregion --- Locations -----------------------------------------

  #region --- Phone numbers --------------------------------------------
  IPhoneNumber? GetPhoneNumber(string id);
  IEnumerable<IPhoneNumber> GetPhoneNumbers();
  IEnumerable<IPhoneNumber> GetPhoneNumbersByPerson(string idPerson);
  #endregion --- Phone numbers -----------------------------------------

  #region --- Mail addresses --------------------------------------------
  IMailAddress? GetMailAddress(string id);
  IEnumerable<IMailAddress> GetMailAddresses();
  IEnumerable<IMailAddress> GetMailAddressesByPerson(string idPerson);
  #endregion --- Mail addresses -----------------------------------------

  #region --- Contact --------------------------------------------
  IContact? GetContact(TKeyId id);
  IEnumerable<IContact> GetContacts();
  IContact? GetContactByPhoneNumber(IPhoneNumber phoneNumber);
  IContact? GetContactByEmail(IMailAddress mailAddress);
  IEnumerable<IContact> GetContactsByLocation(ILocation location);
  #endregion --- Contact -----------------------------------------

  #region --- Departments --------------------------------------------
  IDepartment? GetDepartment(string departmentId);
  IContact? GetHeadOfDepartment(string departmentId);
  IEnumerable<IContact> GetDepartmentMembers(string departmentId);
  #endregion --- Departments -----------------------------------------

}
