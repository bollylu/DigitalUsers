namespace digiuserslib;

public interface IDataSource {

  ValueTask<bool> Open();
  ValueTask<bool> Close();

  ValueTask<bool> Read();
  ValueTask<bool> Save();

  IEnumerable<IPerson> GetPeople();
  IPerson? GetPerson(string id);

  IEnumerable<IDepartment> GetDepartments();
  IEnumerable<IDepartment> GetSubDepartments(string departmentId);
  IPerson? GetHeadOfDepartment(string departmentId);
  IEnumerable<IPerson> GetDepartmentMembers(string departmentId);

  IPerson? GetPersonForPhoneNumber(IPhoneNumber phoneNumber);
  IPerson? GetPersonForEmail(IMailAddress mailAddress);
  IEnumerable<IPerson> GetPeopleForLocation(ILocation location);


}
