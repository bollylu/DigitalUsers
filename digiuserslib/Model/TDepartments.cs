using System.Diagnostics;

namespace digiuserslib {
  public class TDepartments : List<IDepartment>, IDepartments {

    public IDepartment? this[string id] {
      get {
        return this.SingleOrDefault(x => x.Id == id);
      }
    }
  }
}
