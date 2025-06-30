using BLTools;

namespace digiuserslib;

public abstract class ADataSourceWithCache : ADataSource, IDataSource {

  protected readonly TPeople _People = [];
  protected readonly TDepartments _Departments = [];

  protected ADataSourceWithCache() {
    _Tables.Add(new TTableLocationMemory());
    //_Tables.Add(new TTablePeople());
    //_Tables.Add(new TTableDepartment());
    //_Tables.Add(new TTablePhoneNumber());
    //_Tables.Add(new TTableImage());
  }

  public override IEnumerable<IPerson> GetDepartmentMembers(string department) {
    return _People.Where(p => p.Department.Id.Trim().Equals(department, StringComparison.CurrentCultureIgnoreCase));
  }
  public override IEnumerable<IDepartment> GetDepartments() {
    return _People.Select(p => p.Department).Distinct();
  }

  public override IEnumerable<IDepartment> GetSubDepartments(string department) {
    return _People
      .Where(p => p.Department.Id.Trim().Equals(department, StringComparison.CurrentCultureIgnoreCase))
      .Select(p => p.SubDepartment)
      .Distinct();
  }

  public override IPerson? GetHeadOfDepartment(string departmentId) {
    return GetDepartmentMembers(departmentId)
      .SingleOrDefault(p => p.DependsOn.IsEmpty());
  }



  public override IEnumerable<IPerson> GetPeople() {
    TTableLocationMemory? TableLocation = _Tables.SingleOrDefault(x => x.Name == nameof(TTableLocationMemory)) as TTableLocationMemory ??
      throw new InvalidOperationException("Location table not found in data source.");

  }

  public override IPerson? GetPerson(string id) {
    return _People.FirstOrDefault(p => p.Id == id);
  }

  public override IPerson? GetPersonForPhoneNumber(IPhoneNumber phoneNumber) {
    throw new NotImplementedException();
  }

  public override IPerson? GetPersonForEmail(IMailAddress mailAddress) {
    throw new NotImplementedException();
  }

  public override IEnumerable<IPerson> GetPeopleForLocation(ILocation location) {
    throw new NotImplementedException();
  }
}
