
namespace digiuserslib;

public record RAgent : ARecord, IPerson {

  public IName Name { get; set; } = new TName();

  public string Company { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  
  public IPicture Picture { get; set; } = new RPicture();
  public string Notes { get; set; } = string.Empty;

  public List<IMailAddress> EmailAdresses { get; } = [];

  public List<IPhoneNumber> PhoneNumbers { get; } = [];

  public List<ILocation> Locations { get; } = [];

  public List<IDepartment> Departments { get; } = [];

  public IHierarchy? DependsOn { get; set; }

  public override bool IsInvalid => Id.IsInvalid;

  public RAgent() {
  }
  public RAgent(string id) {
    Id = id;
  }


}
