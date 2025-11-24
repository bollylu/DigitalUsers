using System.Diagnostics;
using System.Text.Json.Serialization;

namespace digiuserslib.Model {
  public class TDepartments : List<IDepartment>, IDepartments {

    [JsonIgnore]
    public IDepartment? this[string id] {
      get {
        return this.SingleOrDefault(x => x.Id == id);
      }
    }

    [JsonIgnore]
    public IDepartment Main {
      get {
        IDepartment? Dept = this.FirstOrDefault();
        return Dept ?? throw new InvalidOperationException("No main department found.");
      }
    }
  }
}
