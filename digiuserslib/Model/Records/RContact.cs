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
  public RContact(string id) {
    Id = id;
  }

  public RContact(IContactBasic contactBasic) {
    Id = contactBasic.Id;
    FirstName = contactBasic.FirstName;
    LastName = contactBasic.LastName;
    Company = contactBasic.Company;
    Title = contactBasic.Title;
    Notes = contactBasic.Notes;
  }

  #endregion -------------------------------------------------------------------------------------------------

  public static new RContact BollyLuc => new(RContactBasic.BollyLuc) {
    Departments = {
      RDepartment.GestionInformatique
    },
    PhoneNumbers = {
      new RPhoneNumber() {
        Id = "phone-001",
        Number = "+32471234567",
        Type = EPhoneNumberType.Mobile
      },
      new RPhoneNumber() {
        Id = "phone-002",
        Number = "+32479876543",
        Type = EPhoneNumberType.Work
      }
    },
    Locations = {
      RLocation.CiteAdministrative
    },
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-001",
        Address = "l.bolly@seraing.be"
      }
    }
  };

  public static new RContact MartinSophie => new(RContactBasic.MartinSophie) {
    Departments = {
      RDepartment.GestionInformatique,
      RDepartment.Travaux
    },
    PhoneNumbers = {
      new RPhoneNumber() {
        Id = "phone-003",
        Number = "+32473456789",
        Type = EPhoneNumberType.Mobile
      }
    },
    Locations = {
      RLocation.HotelDeVille
    },
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-002",
        Address = "s.martin@seraing.be"
      }
    }
  };

  public static new RContact DupontJean => new(RContactBasic.DupontJean) {
    Departments = {
      RDepartment.Optimisation
    },
    PhoneNumbers = {
      new RPhoneNumber() {
        Id = "phone-004",
        Number = "+32475678901",
        Type = EPhoneNumberType.Work
      }
    },
    Locations = {
      RLocation.CiteAdministrative
    },
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-003",
        Address = "j.dupont@seraing.be"
      }
    }
  };

  public static new RContact LefevreClaire => new(RContactBasic.LefevreClaire) {
    Departments = {
      RDepartment.Optimisation
    },
    PhoneNumbers = {
      new RPhoneNumber() {
        Id = "phone-005",
        Number = "+32479812345",
        Type = EPhoneNumberType.Mobile
      }
    },
    Locations = {
      RLocation.HotelDeVille
    },
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-004",
        Address = "c.lefevre@seraing.be"
      }
    }
  };

  public static new RContact AdamBruno => new(RContactBasic.AdamBruno) {
    Departments = {
      RDepartment.Direction
    },
    PhoneNumbers = {
      new RPhoneNumber() {
        Id = "phone-006",
        Number = "+32472123456",
        Type = EPhoneNumberType.Work
      }
    },
    Locations = {
      RLocation.HotelDeVille
    },
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-005",
        Address = "b.adam@seraing.be"
      }
    }
  };


}
