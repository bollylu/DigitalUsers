namespace digiuserslib.Model;

public class TTableContactsMemory : ATableMemory<IContact> {

  public override string Name { get; protected set; } = nameof(TTableContactsMemory);
  public override string Description { get; protected set; } = "All contacts from memory";

  public TTableContactsMemory() : base() {
    Initialize();
  }
  protected override void Initialize() {
    if (_IsInitialized) {
      return;
    }
    base.Initialize();
    Add(RContact.AdamBruno);
    Add(RContact.DupontJean);
    Add(RContact.BollyLuc);
    Add(RContact.LefevreClaire);
    Add(RContact.MartinSophie);
    _IsInitialized = true;
  }

}
