namespace digiuserslib.Model;

public record RDepartment : RDepartmentBasic, IDepartment, IInvalid, IEqualityComparer<RDepartment> {

  public IList<IKeyId> HeadsOfDepartment { get; set; } = [];

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(Name);

  public RDepartment() : base() { }
  public RDepartment(string id) : base(id) {
  }
  public RDepartment(IKeyId id) : base(id) {
  }
  public RDepartment(IDepartmentBasic department) : base(department) {
  }
  public RDepartment(IDepartment department) : base(department.Id) {
    Name = department.Name;
    Description = department.Description;
    HeadsOfDepartment = department.HeadsOfDepartment;
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

  public static new RDepartment Empty => new();
  public static new RDepartment Direction => new(RDepartmentBasic.Direction) { HeadsOfDepartment = [RContactBasic.AdamBruno.Id] };
  public static new RDepartment GestionInformatique => new(RDepartmentBasic.GestionInformatique) { HeadsOfDepartment = [RContactBasic.BollyLuc.Id] };
  public static new RDepartment Travaux => new(RDepartmentBasic.Travaux) { HeadsOfDepartment = [new TKeyId("reiser")] };
  public static new RDepartment Optimisation => new(RDepartmentBasic.Optimisation) { HeadsOfDepartment = [new TKeyId("bollyal")] };

}
