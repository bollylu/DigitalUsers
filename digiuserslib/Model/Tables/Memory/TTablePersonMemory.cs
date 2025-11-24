namespace digiuserslib.Model.Tables.Memory;

public class TTablePersonMemory : ATableMemory<IPerson> {

  public override string Name { get; protected set; } = nameof(TTablePersonMemory);
  public override string Description { get; protected set; } = "All agents from memory";

  public TTablePersonMemory() : base() { }
  protected override void Initialize() {
    base.Initialize();
    // Add some dummy data for testing purposes
    Add(RAgent.AdamBruno);
    Add(RAgent.BollyAlain);
    Add(RAgent.BollyLuc);
  }

}
