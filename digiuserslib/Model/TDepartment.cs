namespace digiuserslib;
public class TDepartment : IDepartment, IInvalid, IDependency {
  public string Id { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string DependsOn { get; set; } = string.Empty;
  public bool IsInvalid => Id.Trim() == string.Empty || Name.Trim() == string.Empty;

  public TDepartment() { }
  public TDepartment(string id, string name) {
    Id = id;
    Name = name;
  }

  public static TDepartment Empty => new();
}
