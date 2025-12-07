namespace digiuserslib.Model;

public class TDepartments : List<IDepartment>, IDepartments {

  [JsonIgnore]
  public IDepartment? this[string id] => this.SingleOrDefault(x => x.Id.Value == id);

  [JsonIgnore]
  public IDepartment Main => this.FirstOrDefault() ?? throw new InvalidOperationException("No main department found.");

}
