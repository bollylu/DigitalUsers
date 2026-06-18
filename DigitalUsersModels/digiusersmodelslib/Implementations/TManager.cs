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



  public static TManager ITManager => new("itman") {
    FirstName = "IT",
    LastName = "Manager",
    Company = TCompany.ACS,
    Title = "Responsable IT",
    DepartmentsMemberOf = {
      TDepartment.GestionInformatique
    },
    DepartmentsManaged = {
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
        Address = "it.man@ville.be"
      }
    },
    Manager = DG
  };

  public static TManager DG => new("dg") {
    FirstName = "Directeur",
    LastName = "Général",
    Company = TCompany.ACS,
    Title = "Directeur général",
    DepartmentsMemberOf = {
      TDepartment.Direction
    },
    DepartmentsManaged = {
      TDepartment.Direction
    },
    PhoneNumbers = {
      new TPhoneNumber() {
        Id = "phone-006",
        Number = "+32472123456",
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
        Address = "dg@ville.be"
      }
    }
  };

      return RetVal;
    }
  }


}
