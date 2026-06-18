namespace digiusersmodelslib;

public class TAgent : TContact, IAgent {

  public IDepartments DepartmentsMemberOf { get; init; } = new TDepartments();
  public IManager Manager { get; init; } = new TManager();

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TAgent() : base() { }
  public TAgent(TKeyId id) : base(id) { } 
  public TAgent(IAgent agent) : base(agent.Id) {
    FirstName = agent.FirstName;
    LastName = agent.LastName;
    Company = agent.Company;
    Title = agent.Title;
    DepartmentsMemberOf = new TDepartments(agent.DepartmentsMemberOf);
    PhoneNumbers = agent.PhoneNumbers;
    Locations = agent.Locations;
    Notes = agent.Notes;
    EmailAdresses = agent.EmailAdresses;
    Manager = agent.Manager;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

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
        CountryCode = EPhoneCountry.Belgium,
        Prefix = "475",
        Number = "123456",
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
        CountryCode = EPhoneCountry.Belgium,
        Prefix = "475",
        Number = "678901",
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
        CountryCode = EPhoneCountry.Belgium,
        Prefix = "479",
        Number = "812345",
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
