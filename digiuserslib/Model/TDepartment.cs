using System.Diagnostics.CodeAnalysis;

namespace digiuserslib;
public class TDepartment : IDepartment, IInvalid, IEqualityComparer<TDepartment> {
  public TKeyId Id { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string DependsOn { get; set; } = string.Empty;
  public bool IsInvalid => Id.IsInvalid || Name.Trim() == string.Empty;

  public TDepartment() { }
  public TDepartment(string id, string name) {
    Id = id;
    Name = name;
  }

  public static TDepartment Empty => new();

  public bool Equals(TDepartment? x, TDepartment? y) {
    if (x is null || y is null) {
      return false;
    }

    if (x.Id != y.Id) {
      return false;
    }

    return true;
  }

  public int GetHashCode([DisallowNull] TDepartment obj) {
    return obj.Id.GetHashCode();
  }
}
