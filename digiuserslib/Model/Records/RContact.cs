namespace digiuserslib.Model;

public record RContact : RContactBasic, IContact {

  public IPicture Picture { get; set; } = new RPicture();

  public TMailAddresses EmailAdresses { get; } = [];
  public TPhoneNumbers PhoneNumbers { get; } = [];
  public TLocations Locations { get; } = [];
  public TDepartments Departments { get; } = [];

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(FullName);

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public RContact() {
  }
  public RContact(string id) : base(id) {
  }
  public RContact(IKeyId id) : base(id) {
  }
  public RContact(IContactBasic contactBasic) : base(contactBasic) {
  }

  #endregion -------------------------------------------------------------------------------------------------

  public static new RContact BollyLuc => new(RContactBasic.BollyLuc) {
    Departments = { RDepartment.GestionInformatique },
    PhoneNumbers = { RPhoneNumber.BollyLucOffice, RPhoneNumber.BollyLucMobile },
    Locations = { RLocation.CiteAdministrative },
    EmailAdresses = { RMailAddress.BollyLuc }
  };

  public static new RContact MartinSophie => new(RContactBasic.MartinSophie) {
    Departments = { RDepartment.GestionInformatique, RDepartment.Travaux },
    PhoneNumbers = { new RPhoneNumber("+32473456789") { Number = "+32473456789", Type = EPhoneNumberType.Mobile } },
    Locations = { RLocation.HotelDeVille },
    EmailAdresses = { new RMailAddress("s.martin@seraing.be") }
  };

  public static new RContact DupontJean => new(RContactBasic.DupontJean) {
    Departments = { RDepartment.Optimisation },
    PhoneNumbers = { new RPhoneNumber("+3243308715") { CountryCode=EPhoneCountry.Belgium, Prefix="4", Number="3308", Extension="715",  Type = EPhoneNumberType.Work } },
    Locations = { RLocation.CiteAdministrative },
    EmailAdresses = { new RMailAddress("j.dupont@seraing.be") }
  };

  public static new RContact LefevreClaire => new(RContactBasic.LefevreClaire) {
    Departments = {
      RDepartment.Optimisation
    },
    PhoneNumbers = {
      new RPhoneNumber("+32479812345") {
        Number = "+32479812345",
        Type = EPhoneNumberType.Mobile
      }
    },
    Locations = {
      RLocation.HotelDeVille
    },
    EmailAdresses = {
      new RMailAddress("c.lefevre@seraing.be") {
        Address = "c.lefevre@seraing.be"
      }
    }
  };

  public static new RContact AdamBruno => new(RContactBasic.AdamBruno) {
    Departments = {
      RDepartment.Direction
    },
    PhoneNumbers = {
      new RPhoneNumber("+32472123456") {
        Number = "+32472123456",
        Type = EPhoneNumberType.Work
      }
    },
    Locations = {
      RLocation.HotelDeVille
    },
    EmailAdresses = { RMailAddress.AdamBruno }
  };


}
