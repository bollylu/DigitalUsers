namespace digiuserslib.Model;

public class TTableDepartmentsMemory : ATableMemory<IDepartment> {
  public override string Name { get; protected set; } = nameof(TTableDepartmentsMemory);
  public override string Description { get; protected set; } = "All Departments";

  public TTableDepartmentsMemory() : base() {
    Initialize();
  }

  protected override void Initialize() {
    if (_IsInitialized) {
      return;
    }
    base.Initialize();
    Add(RDepartment.Direction);
    Add(RDepartment.GestionInformatique);
    Add(RDepartment.Travaux);
    Add(RDepartment.Optimisation);
    _IsInitialized = true;
  }
}

