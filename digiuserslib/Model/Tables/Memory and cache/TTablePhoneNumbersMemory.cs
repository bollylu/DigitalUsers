namespace digiuserslib.Model;

public class TTablePhoneNumbersMemory : ATableMemory<IPhoneNumber> {
  public override string Name { get; protected set; } = nameof(TTablePhoneNumbersMemory);
  public override string Description { get; protected set; } = "All Phone numbers";

  public TTablePhoneNumbersMemory() : base() { 
    Initialize();
  }

  protected override void Initialize() {
    if (_IsInitialized) {
      return;
    }
    base.Initialize();
    Add(RPhoneNumber.BollyLucOffice);
    Add(RPhoneNumber.BollyAlainOffice);
    Add(RPhoneNumber.BollyLucMobile);
    _IsInitialized = true;
  }

  public IPhoneNumber? Create(IPhoneNumber phoneNumber) {
    return Add(phoneNumber);
  }
}

