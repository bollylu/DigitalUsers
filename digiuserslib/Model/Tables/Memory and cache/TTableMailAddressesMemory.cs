namespace digiuserslib.Model;

public class TTableMailAddressesMemory : ATableMemory<IMailAddress> {

  public override string Name { get; protected set; } = nameof(TTableMailAddressesMemory);
  public override string Description { get; protected set; } = "All email addresses";

  public TTableMailAddressesMemory() : base() {
    Initialize();
  }

  protected override void Initialize() {
    if (_IsInitialized) {
      return;
    }
    base.Initialize();
    _Records.Add(new RMailAddress() { Id = "bollylu", Address = "l.bolly@seraing.be", DisplayName = "Luc Bolly" });
    _Records.Add(new RMailAddress() { Id = "bollyal", Address = "a.bolly@seraing.be", DisplayName = "Alain Bolly" });
    _Records.Add(new RMailAddress() { Id = "verdial", Address = "a.verdin@seraing.be", DisplayName = "Alain Verdin" });
    _IsInitialized = true;
  }

}
