namespace digiusersmodelslib;

public class TAgent : TContact, IAgent {

  public TAgent() : base() { }
  public TAgent(string id) : base(id) { }

  public IDepartments DepartmentsMemberOf { get; init; } = new TDepartments();
  
  public IManager Manager { get; init; } = new TManager();

  public static TAgent MartinSophie => new("martiso") {
    FirstName = "Sophie",
    LastName = "Martin",
    Company = TCompany.ACS,
    Title = "Technicienne IT",
    DepartmentsMemberOf = {
      TDepartment.GestionInformatique,
      TDepartment.Travaux
    },
    PhoneNumbers = {
      new TPhoneNumber() {
        Id = "phone-003",
        Number = "+32473456789",
        Type = EPhoneNumberType.Mobile
      }
    },
    Locations = {
      TLocation.HotelDeVille
    },
    Notes = "Specializes in network infrastructure and maintenance.",
    EmailAdresses = {
      new TMailAddress() {
        Id = "email-002",
        Address = "s.martin@ville.be"
      }
    }
  };

  public static TAgent DupontJean => new("duponje") {
    FirstName = "Jean",
    LastName = "Dupont",
    Company = TCompany.ACS,
    Title = "Analyste IT",
    DepartmentsMemberOf = {
      TDepartment.Optimisation
    },
    PhoneNumbers = {
      new TPhoneNumber() {
        Id = "phone-004",
        Number = "+32475678901",
        Type = EPhoneNumberType.Work
      }
    },
    Locations = {
      TLocation.CiteAdministrative
    },
    Notes = "Focuses on system optimization and performance analysis.",
    EmailAdresses = {
      new TMailAddress() {
        Id = "email-003",
        Address = "j.dupont@ville.be"
      }
    }
  };

  public static TAgent LefevreClaire => new("lefevcl") {
    FirstName = "Claire",
    LastName = "Lefevre",
    Company = TCompany.ACS,
    Title = "Consultante IT",
    DepartmentsMemberOf = {
      TDepartment.Optimisation
    },
    PhoneNumbers = {
      new TPhoneNumber() {
        Id = "phone-005",
        Number = "+32479812345",
        Type = EPhoneNumberType.Mobile
      }
    },
    Locations = {
      TLocation.HotelDeVille
    },
    Notes = "Provides strategic IT consulting and project management.",
    EmailAdresses = {
      new TMailAddress() {
        Id = "email-004",
        Address = "c.lefevre@ville.be"
      }
    }
  };

}
