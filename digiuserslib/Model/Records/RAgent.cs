
namespace digiuserslib;

public record RAgent : ARecord, IPerson {

  public IName Name { get; set; } = new TName();

  public string Company { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;

  public IPicture Picture { get; set; } = new RPicture();
  public string Notes { get; set; } = string.Empty;

  public List<IMailAddress> EmailAdresses { get; } = [];

  public TPhoneNumbers PhoneNumbers { get; } = [];

  public List<ILocation> Locations { get; } = [];

  public TDepartments Departments { get; } = [];

  public IHierarchy? DependsOn { get; set; }

  public override bool IsInvalid => Id.IsInvalid;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public RAgent() {
  }
  public RAgent(string id) {
    Id = id;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public static RAgent BollyLuc {
    get {
      RAgent RetVal = new RAgent("bollylu") {
        Name = new TName("Bolly", "Luc"),
        Company = "Ville de Seraing",
        Title = "IT Manager"
      };
      RetVal.EmailAdresses.Add(RMailAddress.BollyLuc);
      RetVal.EmailAdresses.Add(RMailAddress.GestionInformatique);
      RetVal.PhoneNumbers.Add(RPhoneNumber.BollyLucOffice);
      RetVal.PhoneNumbers.Add(RPhoneNumber.BollyLucMobile);
      RetVal.Locations.Add(RLocation.CiteAdministrative);
      RetVal.Departments.Add(RDepartment.GestionInformatique);
      RetVal.DependsOn = RDepartment.Direction;
      return RetVal;
    }
  }

  public static RAgent BollyAlain {
    get {
      RAgent RetVal = new RAgent("bollyal") {
        Name = new TName("Bolly", "Alain"),
        Company = "Ville de Seraing",
        Title = "DPO"
      };
      RetVal.EmailAdresses.Add(RMailAddress.BollyAlain);
      RetVal.PhoneNumbers.Add(RPhoneNumber.BollyAlainOffice);
      RetVal.Locations.Add(RLocation.HotelDeVille);
      RetVal.Departments.Add(RDepartment.Optimisation);
      RetVal.DependsOn = RDepartment.Direction;
      return RetVal;
    }
  }

  public static RAgent AdamBruno {
    get {
      RAgent RetVal = new RAgent("adambr") {
        Name = new TName("Adam", "Bruno"),
        Company = "Ville de Seraing",
        Title = "Directeur général"
      };
      RetVal.EmailAdresses.Add(RMailAddress.AdamBruno);
      RetVal.Locations.Add(RLocation.HotelDeVille);
      RetVal.Departments.Add(RDepartment.Direction);
      return RetVal;
    }
  }

}
