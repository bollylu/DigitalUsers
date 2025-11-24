using System.Diagnostics;

namespace digiuserslib.Model {
  public class TDepartments : List<IDepartment>, IDepartments {

    public IDepartment? this[string id] {
      get {
        return this.SingleOrDefault(x => x.Id == id);
      }
    }

    public IDepartment Main {
      get {
        IDepartment? Dept = this.FirstOrDefault();
        return Dept ?? throw new InvalidOperationException("No main department found.");
      }
    }
  }
}
