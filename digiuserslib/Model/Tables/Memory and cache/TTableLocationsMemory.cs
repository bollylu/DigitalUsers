namespace digiuserslib.Model;

public class TTableLocationsMemory : ATableMemory<ILocation> {

  public override string Name { get; protected set; } = nameof(TTableLocationsMemory);
  public override string Description { get; protected set; } = "All locations";

  public TTableLocationsMemory() : base() {
    Initialize();
  }

  protected override void Initialize() {
    if (_IsInitialized) {
      return;
    }
    base.Initialize();
    _Records.Add(RLocation.CiteAdministrative);
    _Records.Add(RLocation.HotelDeVille);
    _IsInitialized = true;
  }
}
