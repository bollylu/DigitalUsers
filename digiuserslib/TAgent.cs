namespace digiuserslib;

public class TAgent : IPerson {
  public string Id { get; set; } = string.Empty;
  public IName Name { get; set; } = new TName();
  public IMailAddress EmailPrimary { get; set; } = new TMailAddress();
  public IMailAddress EmailSecondary { get; set; } = new TMailAddress();
  public IPhoneNumber PhoneNumberPrimary { get; set; } = new TPhoneNumber();
  public IPhoneNumber PhoneNumberSecondary { get; set; } = new TPhoneNumber();
  public IPhoneNumber PhoneNumberMobile { get; set; } = new TPhoneNumber();
  public string Company { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string Department { get; set; } = string.Empty;
  public string SubDepartment { get; set; } = string.Empty;
  public ILocation WorkLocationPrimary { get; set; } = new TLocation();
  public ILocation WorkLocationSecondary { get; set; } = new TLocation();
  public IPicture Picture { get; set; } = new TPicture();
  public string Notes { get; set; } = string.Empty;
  public string DependsOn { get; set; } = string.Empty;

  public bool IsInvalid => Id.Trim() == string.Empty;

  public TAgent() {
  }
  public TAgent(string id) {
    Id = id;
  }


}
