namespace digiuserslib;

public interface IDataSource {

  ValueTask<bool> Open();
  ValueTask<bool> Close();

  ValueTask<bool> Read();
  ValueTask<bool> Save();

  public IEnumerable<IPerson> GetPeople();
  public IPerson? GetPerson(string id);

  public IEnumerable<IPerson> GetPeopleForDepartment(string department);

  public IPerson? GetPersonForPhoneNumber(IPhoneNumber phoneNumber);
  public IPerson? GetPersonForEmail(IMailAddress mailAddress);
  public IEnumerable<IPerson> GetPeopleForLocation(ILocation location);
}
