namespace digiuserslib.Model;

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

  public override bool IsInvalid => Id.IsInvalid;

  public RAgent() {
  }
  public RAgent(string id) {
    Id = id;
  }

  public static RAgent BollyLuc => new("agent-001") {
    Name = new TName("Luc", "Bolly"),
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

  public static RAgent MartinSophie => new("agent-002") {
    Name = new TName("Sophie", "Martin"),
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

  public static RAgent DupontJean => new("agent-003") {
    Name = new TName("Jean", "Dupont"),
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

  public static RAgent LefevreClaire => new("agent-004") {
    Name = new TName("Claire", "Lefevre"),
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

  public static RAgent AdamBruno => new("agent-005") {
    Name = new TName("Bruno", "Adam"),
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
