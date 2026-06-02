namespace digiusersmodelslib;

public class TManager : TAgent, IManager {

  public TManager() : base() { }
  public TManager(string id) : base(id) { }

  //public IEnumerable<IAgent> DirectReports {
  //  get {
  //    if (Departments.IsEmpty()) {
  //      return Enumerable.Empty<IAgent>();
  //    }
  //    return Departments.Where(d => d.Manager.Id == Id || d.Deputy.Id == Id);
  //  };
  //  init;
  //} = [];

  public static TManager BollyLuc => new("bollylu") {
    FirstName = "Luc",
    LastName = "Bolly",
    Company = TCompany.AcSeraing,
    Title = "Responsable IT",
    Departments = {
      TDepartment.GestionInformatique
    },
    PhoneNumbers = {
      new TPhoneNumber() {
        Id = "phone-001",
        Number = "+32471234567",
        Type = EPhoneNumberType.Mobile
      },
      new TPhoneNumber() {
        Id = "phone-002",
        Number = "+32479876543",
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
        Address = "l.bolly@seraing.be"
      }
    },
    Manager = AdamBruno
  };

  public static TManager AdamBruno => (new("adambr") {
    FirstName = "Bruno",
    LastName = "Adam",
    Company = TCompany.AcSeraing,
    Title = "Directeur général",
    Departments = {
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
        Address = "b.adam@seraing.be"
      }
    }).AddAgent(BollyLuc);
  };

  
}
