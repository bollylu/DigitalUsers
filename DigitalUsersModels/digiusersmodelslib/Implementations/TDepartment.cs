namespace digiusersmodelslib;
public class TDepartment : ARecord, IDepartment, IInvalid, IEqualityComparer<TDepartment> {

  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public IManager Manager { get; init; } = new TManager();
  public IManager Deputy { get; init; } = new TManager();

  public IAgents Agents { get; } = new TAgents();


  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(Name);

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDepartment() : base() { }
  public TDepartment(TKeyId id) : base(id) { }
  public TDepartment(TKeyId id, string name) {
    Id = id;
    Name = name;
  }

  public TDepartment(TKeyId id, string name, IAgents agents) {
    Id = id;
    Name = name;
    Agents = new TAgents(agents);
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public bool Equals(TDepartment? x, TDepartment? y) {
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

  public int GetHashCode(TDepartment obj) {
    return obj.Id.GetHashCode();
  }

  public static TDepartment Empty => new();
  public static TDepartment Direction => new() { Id = "direction", Name = "Direction générale", Manager = TManager.DG };
  public static TDepartment GestionInformatique => new() { Id = "gestinfo", Name = "Gestion informatique", Manager = TManager.ITManager };
  public static TDepartment Travaux => new() { Id = "travaux", Name = "Travaux" };
  public static TDepartment Optimisation => new() { Id = "optimisation", Name = "Optimisation" };

}
