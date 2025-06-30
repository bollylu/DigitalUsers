namespace digiuserslib;
public class TTableMailAddressesMemory : ATableMemory<IMailAddress> {

  public override string Name { get; protected set; } = nameof(TTableMailAddressesMemory);
  public override string Description { get; protected set; } = "All email addresses";

  protected TTableMailAddressesMemory() : base() { }

  protected override void _Initialize() {
    _Records.Add(RLocation.CiteAdministrative);
    _Records.Add(RLocation.HotelDeVille);
  }

}
