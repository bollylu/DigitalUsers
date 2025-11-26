namespace digiuserslib.Model;

public record RContact : ARecord, IContact {

  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;

  public string Company { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public IPicture Picture { get; set; } = new RPicture();
  public string Notes { get; set; } = string.Empty;

  public TMailAddresses EmailAdresses { get; } = [];
  public TPhoneNumbers PhoneNumbers { get; } = [];
  public TLocations Locations { get; } = [];
  public TDepartments Departments { get; } = [];

  [JsonIgnore]
  public string FullName => $"{FirstName} {LastName}";

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(FullName);

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public RContact() {
  }
  public RContact(string id) {
    Id = id;
  }

  #endregion -------------------------------------------------------------------------------------------------

  public static RContact BollyLuc => new("bollylu") {
    FirstName = "Luc",
    LastName = "Bolly",
    Company = "Ville de Seraing",
    Title = "Responsable IT",
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
    Notes = "Expert in customer support and troubleshooting.",
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-001",
        Address = "l.bolly@seraing.be"
      }
    }
  };

  public static RContact MartinSophie => new("martiso") {
    FirstName = "Sophie",
    LastName = "Martin",
    Company = "Ville de Seraing",
    Title = "Technicienne IT",
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
    Notes = "Specializes in network infrastructure and maintenance.",
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-002",
        Address = "s.martin@seraing.be"
      }
    }
  };

  public static RContact DupontJean => new("duponje") {
    FirstName = "Jean",
    LastName = "Dupont",
    Company = "Ville de Seraing",
    Title = "Analyste IT",
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
    Notes = "Focuses on system optimization and performance analysis.",
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-003",
        Address = "j.dupont@seraing.be"
      }
    }
  };

  public static RContact LefevreClaire => new("lefevcl") {
    FirstName = "Claire",
    LastName = "Lefevre",
    Company = "Ville de Seraing",
    Title = "Consultante IT",
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
    Notes = "Provides strategic IT consulting and project management.",
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-004",
        Address = "c.lefevre@seraing.be"
      }
    }
  };

  public static RContact AdamBruno => new("adambr") {
    FirstName = "Bruno",
    LastName = "Adam",
    Company = "Ville de Seraing",
    Title = "Directeur général",
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
    Notes = "Dirige la boite",
    EmailAdresses = {
      new RMailAddress() {
        Id = "email-005",
        Address = "b.adam@seraing.be"
      }
    }
  };


}
