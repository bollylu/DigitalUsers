using System.Diagnostics.CodeAnalysis;

namespace digiuserslib;
public record RDepartment : IDepartment, IInvalid, IEqualityComparer<RDepartment> {
  public TKeyId Id { get; set; } = string.Empty;

  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public TKeyId HeadOfDepartment { get; set; } = TKeyId.Empty;
  public IHierarchy? DependsOn { get; set; } = null;
  public bool IsInvalid => Id.IsInvalid || Name.Trim() == string.Empty;

  public RDepartment() { }
  public RDepartment(string id, string name) {
    Id = id;
    Name = name;
  }

  public static RDepartment Empty => new();
  public static RDepartment Direction => new() { Id = "direction", Name = "Direction générale", HeadOfDepartment = new TKeyId("adambr") };
  public static RDepartment GestionInformatique => new() { Id = "gestinfo", Name = "Gestion informatique", HeadOfDepartment = new TKeyId("bollylu") };
  public static RDepartment Travaux => new() { Id = "travaux", Name = "Travaux", HeadOfDepartment = new TKeyId("reiser") };
  public static RDepartment Optimisation => new() { Id = "optimisation", Name = "Optimisation", HeadOfDepartment = new TKeyId("bollyal") };





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
