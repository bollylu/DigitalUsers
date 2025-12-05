namespace digiuserslib.Model;
public record RDepartment : ARecord, IDepartment, IInvalid, IEqualityComparer<RDepartment> {

  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public IKeyId HeadOfDepartment { get; set; } = IKeyId.Empty;

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(Name);

  public RDepartment() { }
  public RDepartment(string id, string name) {
    Id = id;
    Name = name;
  }
  
  public bool Equals(RDepartment? x, RDepartment? y) {
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

  public int GetHashCode(RDepartment obj) {
    return obj.Id.GetHashCode();
  }

  public static RDepartment Empty => new();
  public static RDepartment Direction => new() { Id = "direction", Name = "Direction générale", HeadOfDepartment = new TKeyId("adambr") };
  public static RDepartment GestionInformatique => new() { Id = "gestinfo", Name = "Gestion informatique", HeadOfDepartment = new TKeyId("bollylu") };
  public static RDepartment Travaux => new() { Id = "travaux", Name = "Travaux", HeadOfDepartment = new TKeyId("reiser") };
  public static RDepartment Optimisation => new() { Id = "optimisation", Name = "Optimisation", HeadOfDepartment = new TKeyId("bollyal") };

}
