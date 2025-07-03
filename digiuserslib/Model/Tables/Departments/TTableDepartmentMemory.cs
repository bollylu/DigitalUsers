namespace digiuserslib;

public class TTableDepartmentMemory : ATableMemory<IDepartment> {
  public override string Name { get; protected set; } = nameof(TTableDepartmentMemory);
  public override string Description { get; protected set; } = "All Departments";

  public TTableDepartmentMemory() : base() { }

  protected override void _Initialize() {
    _Records.Add(RDepartment.Direction);
    _Records.Add(RDepartment.GestionInformatique);
    _Records.Add(RDepartment.Travaux);
    _Records.Add(RDepartment.Optimisation);
  }
}

