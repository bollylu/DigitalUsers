using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLTools.Diagnostic.Logging;

namespace digiuserslib.DataSources;
public abstract class ADataSource : ALoggable, IDataSource {
  public abstract ValueTask<bool> Open();
  public abstract ValueTask<bool> Close();
  public abstract ValueTask<bool> Read();
  public abstract ValueTask<bool> Save();
  public abstract IEnumerable<IPerson> GetPeople();
  public abstract IPerson? GetPerson(string id);
  public abstract IEnumerable<IPerson> GetDepartmentMembers(string departmentId);
  public abstract IPerson? GetPersonForPhoneNumber(IPhoneNumber phoneNumber);
  public abstract IPerson? GetPersonForEmail(IMailAddress mailAddress);
  public abstract IEnumerable<IPerson> GetPeopleForLocation(ILocation location);
  public abstract IPerson? GetHeadOfDepartment(string departmentId);
  public abstract IEnumerable<IDepartment> GetDepartments();
  public abstract IEnumerable<IDepartment> GetSubDepartments(string departmentId);
}
