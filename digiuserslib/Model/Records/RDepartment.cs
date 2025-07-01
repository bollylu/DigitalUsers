using System.Diagnostics.CodeAnalysis;

namespace digiuserslib;
public record RDepartment : IDepartment, IInvalid, IEqualityComparer<RDepartment> {
  public TKeyId Id { get; set; } = string.Empty;

  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public IPerson? HeadOfDepartment { get; set; } = new RAgent();
  public IHierarchy? DependsOn { get; set; } = null;
  public bool IsInvalid => Id.IsInvalid || Name.Trim() == string.Empty;

  public RDepartment() { }
  public RDepartment(string id, string name) {
    Id = id;
    Name = name;
  }

  public static RDepartment Empty => new();

  public bool Equals(RDepartment? x, RDepartment? y) {
    if (x is null || y is null) {
      return false;
    }

    if (x.Id != y.Id) {
      return false;
    }

    return true;
  }

  public int GetHashCode([DisallowNull] RDepartment obj) {
    return obj.Id.GetHashCode();
  }
}
