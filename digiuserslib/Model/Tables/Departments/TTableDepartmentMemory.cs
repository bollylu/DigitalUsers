namespace digiuserslib;

public class TTableDepartmentMemory : ATableMemory<IDepartment> {
  public override string Name { get; protected set; } = nameof(TTableDepartmentMemory);
  public override string Description { get; protected set; } = "All Departments";

  public TTableDepartmentMemory() : base() { }

  protected override void _Initialize() {
    Add(RDepartment.Direction);
    Add(RDepartment.GestionInformatique);
    Add(RDepartment.Travaux);
    Add(RDepartment.Optimisation);
  }
}

