namespace digiuserslib.Model;
public record RDepartmentBasic : ARecord, IDepartmentBasic, IEqualityComparer<RDepartmentBasic> {

  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(Name);

  public RDepartmentBasic() :base() { }
  public RDepartmentBasic(string id) : base(id) {
  }
  public RDepartmentBasic(IKeyId id) : base(id) {
  }
  public RDepartmentBasic(IDepartmentBasic department) : base(department.Id) {
    Name = department.Name;
    Description = department.Description;
  }

  public bool Equals(RDepartmentBasic? x, RDepartmentBasic? y) {
    if (x is null && y is null) {
      return true;
    }

    if (x is null || y is null) {
      return false;
    }

    if (x.Id != y.Id) {
      return false;
    }

    return true;
  }

  public int GetHashCode(RDepartmentBasic obj) {
    return obj.Id.GetHashCode();
  }

  public static RDepartmentBasic Empty => new();
  public static RDepartmentBasic Direction => new("direction") { Name = "Direction générale"};
  public static RDepartmentBasic GestionInformatique => new("gestinfo") { Name = "Gestion informatique" };
  public static RDepartmentBasic Travaux => new("travaux") { Name = "Travaux"};
  public static RDepartmentBasic Optimisation => new("optimisation") { Name = "Optimisation"};

}
