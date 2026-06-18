namespace digiusersmodelslib;

public class TManager : TAgent, IManager {

  public IDepartments DepartmentsManaged { get; init; } = new TDepartments();

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TManager() : base() { }
  public TManager(string id) : base(id) { }
  public TManager(IAgent agent, IDepartments departmentsManaged) : base(agent) {
    DepartmentsManaged = new TDepartments(departmentsManaged);
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------



  public static TManager BollyLuc => new("bosspi") {
    FirstName = "Pierre",
    LastName = "Boss",
    Company = TCompany.ACV,
    Title = "Responsable IT",
    Departments = {
      TDepartment.GestionInformatique
    },
    PhoneNumbers = {
      new TPhoneNumber() {
        Id = "phone-001",
        CountryCode = EPhoneCountry.Belgium,
        Prefix = "475",
        Number = "987654",
        Type = EPhoneNumberType.Mobile
      },
      new TPhoneNumber() {
        Id = "phone-002",
        CountryCode = EPhoneCountry.Belgium,
        Prefix = "2",
        Number = "8376543",
        Type = EPhoneNumberType.Work
      }
    },
    Locations = {
      TLocation.CiteAdministrative
    },
    Notes = "Expert in customer support and troubleshooting.",
    EmailAdresses = {
      new TMailAddress() {
        Id = "email-001",
        Address = "p.boss@ville.be"
      }
    },
    Manager = GodHimself
  };

  public static TManager GodHimself {
    get {
      TManager RetVal = new("godhi") {
        FirstName = "God",
        LastName = "Himself",
        Company = TCompany.ACV,
        Title = "Directeur général",
        Departments = {
        TDepartment.Direction
      },
        PhoneNumbers = {
        new TPhoneNumber() {
          Id = "phone-006",
          CountryCode = EPhoneCountry.Belgium,
          Prefix = "472",
          Number = "123456",
          Type = EPhoneNumberType.Work
        }
      },
        Locations = {
        TLocation.HotelDeVille
      },
        Notes = "Dirige la boite",
        EmailAdresses = {
        new TMailAddress() {
          Id = "email-005",
          Address = "g.himself@ville.be"
        }
      }
      };

      return RetVal;
    }
  }


}
