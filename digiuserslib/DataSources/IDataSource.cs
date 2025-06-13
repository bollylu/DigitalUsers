namespace digiuserslib;

public interface IDataSource {

  bool Open();
  bool Close();

  bool Read();
  bool Save();

  public IEnumerable<IPerson> GetPeople();
  public IPerson? GetPerson(string id);

  public IEnumerable<IPerson> GetPeopleForDepartment(string department);

  public IPerson? GetPersonForPhoneNumber(IPhoneNumber phoneNumber);
  public IPerson? GetPersonForEmail(IMailAddress mailAddress);
  public IEnumerable<IPerson> GetPeopleForLocation(ILocation location);
}
