namespace digiuserslib;

public record TAgent : ARecord, IPerson {

  public IName Name { get; set; } = new TName();
  public IMailAddress EmailPrimary { get; set; } = new RMailAddress();
  public IMailAddress EmailSecondary { get; set; } = new RMailAddress();
  public IPhoneNumber PhoneNumberPrimary { get; set; } = new TPhoneNumber();
  public IPhoneNumber PhoneNumberSecondary { get; set; } = new TPhoneNumber();
  public IPhoneNumber PhoneNumberMobile { get; set; } = new TPhoneNumber();
  public string Company { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public IDepartment Department { get; set; } = new TDepartment();
  public IDepartment SubDepartment { get; set; } = new TDepartment();
  public ILocation WorkLocationPrimary { get; set; } = new RLocation();
  public ILocation WorkLocationSecondary { get; set; } = new RLocation();
  public IPicture Picture { get; set; } = new TPicture();
  public string Notes { get; set; } = string.Empty;
  public string DependsOn { get; set; } = string.Empty;

  public override bool IsInvalid => Id.IsInvalid;

  public TAgent() {
  }
  public TAgent(string id) {
    Id = id;
  }


}
