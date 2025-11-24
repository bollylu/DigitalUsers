using System.Diagnostics;

namespace digiuserslib.Model {
  public class TDepartments : List<IDepartment>, IDepartments {

    public IDepartment? this[string id] {
      get {
        return this.SingleOrDefault(x => x.Id == id);
      }
    }
  }
}
