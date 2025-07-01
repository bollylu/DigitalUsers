namespace digiuserslib;
public class TTableMailAddressesMemory : ATableMemory<IMailAddress> {

  public override string Name { get; protected set; } = nameof(TTableMailAddressesMemory);
  public override string Description { get; protected set; } = "All email addresses";

  protected TTableMailAddressesMemory() : base() { }

  protected override void _Initialize() {
    _Records.Add(new RMailAddress() { Id = "bollylu", Address = "l.bolly@seraing.be", DisplayName = "Luc Bolly" });
    _Records.Add(new RMailAddress() { Id = "bollyal", Address = "a.bolly@seraing.be", DisplayName = "Alain Bolly" });
    _Records.Add(new RMailAddress() { Id = "verdial", Address = "a.verdin@seraing.be", DisplayName = "Alain Verdin" });
  }

}
