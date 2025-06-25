using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLTools;
using BLTools.Diagnostic.Logging;

namespace digiuserslib.DataSources;
public abstract class ADataSourceWithCache : ADataSource, IDataSource {

  protected readonly TPeople _People = [];
  protected readonly TDepartments _Departments = [];

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
    return _People;
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
