namespace digiuserslib;

public class TTablePhoneNumbersMemory : ATableMemory<IPhoneNumber> {
  public override string Name { get; protected set; } = nameof(TTablePhoneNumbersMemory);
  public override string Description { get; protected set; } = "All Phone numbers";

  public TTablePhoneNumbersMemory() : base() { }

  protected override void _Initialize() {
    Add(RPhoneNumber.BollyLucOffice);
    Add(RPhoneNumber.BollyAlainOffice);
    Add(RPhoneNumber.BollyLucMobile);
  }
}

