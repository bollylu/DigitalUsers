
namespace digiuserslib {
  public class TDataSourceMemory : IDataSource {

    private readonly List<IPerson> _People = new List<IPerson>();

    public TDataSourceMemory() {
      _Initialize();
    }

    private void _Initialize() {
      _People.Add(new TAgent("geradde") {
        Name = new TName() { FirstName = "Deborah", LastName = "Géradon" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "43", Number = "308", Extension = "001" },
        PhoneNumberMobile = new TPhoneNumber() { Prefix = "470", Number = "123456" },
        EmailPrimary = new TMailAddress() { Address = "d.geradon@seraing.be" },
        EmailSecondary = new TMailAddress() { Address = "bourgmestre@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Hôtel de ville", Address1 = "Place Communale, 8", AddressDetails = "5ème étage, Informatique" },
        Company = "Ville de Seraing",
        Department = "Direction",
        SubDepartment = "",
        Title = "Bourgmestre"
      });
      _People.Add(new TAgent("adambr") {
        Name = new TName() { FirstName = "Bruno", LastName = "Adam" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "43", Number = "308", Extension = "002" },
        PhoneNumberMobile = new TPhoneNumber() { Prefix = "470", Number = "123457" },
        EmailPrimary = new TMailAddress() { Address = "b.adam@seraing.be" },
        EmailSecondary = new TMailAddress() { Address = "dg@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Hôtel de ville", Address1 = "Place Communale, 8", AddressDetails = "5ème étage, Informatique" },
        Company = "Ville de Seraing",
        Department = "Direction",
        SubDepartment = "",
        Title = "Directeur Général",
        DependsOn = "geradde"
      });
      _People.Add(new TAgent("paparal") {
        Name = new TName() { FirstName = "Alexandra", LastName = "Paparelli" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "43", Number = "308", Extension = "003" },
        PhoneNumberMobile = new TPhoneNumber() { Prefix = "470", Number = "123458" },
        EmailPrimary = new TMailAddress() { Address = "a.paparelli@seraing.be" },
        EmailSecondary = new TMailAddress() { Address = "dga@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Hôtel de ville", Address1 = "Place Communale, 8", AddressDetails = "5ème étage, Informatique" },
        Company = "Ville de Seraing",
        Department = "Direction",
        SubDepartment = "",
        Title = "Directrice Générale adjointe",
        DependsOn = "geradde"
      });
      _People.Add(new TAgent("bollylu") {
        Name = new TName() { FirstName = "Luc", LastName = "Bolly" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "43", Number = "308", Extension = "710" },
        PhoneNumberMobile = new TPhoneNumber() { Prefix = "474", Number = "960084" },
        EmailPrimary = new TMailAddress() { Address = "l.bolly@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Cité administrative", Address1 = "Place Kuborn, 5", AddressDetails = "5ème étage, Informatique" },
        Company = "Ville de Seraing",
        Department = "Gestion informatique",
        SubDepartment = "Head of IT",
        Title = "Responsable IT",
        DependsOn = "adambr"
      });
      _People.Add(new TAgent("bollyal") {
        Name = new TName() { FirstName = "Alain", LastName = "Bolly" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "43", Number = "308", Extension = "586" },
        PhoneNumberMobile = new TPhoneNumber() { Prefix = "470", Number = "123459" },
        EmailPrimary = new TMailAddress() { Address = "a.bolly@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Hôtel de ville", Address1 = "Place xxx,8", AddressDetails = "Rez" },
        Company = "Ville de Seraing",
        Department = "Optimisation",
        Title = "Responsable optimisation",
        DependsOn = "adambr"
      });
    }

    public IEnumerable<IPerson> GetPeople() {
      return _People;
    }

    public IPerson? GetPerson(string id) {
      return _People.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<IPerson> GetPeopleForDepartment(string department) {
      return _People.Where(p => p.Department.Contains(department, StringComparison.CurrentCultureIgnoreCase));
    }

    public IPerson? GetPersonForPhoneNumber(IPhoneNumber phoneNumber) {
      throw new NotImplementedException();
    }

    public IPerson? GetPersonForEmail(IMailAddress mailAddress) {
      throw new NotImplementedException();
    }

    public IEnumerable<IPerson> GetPeopleForLocation(ILocation location) {
      throw new NotImplementedException();
    }

    public bool Open() {
      return true;
    }

    public bool Close() {
      return true;
    }

    public bool Read() {
      _Initialize();
      return true;
    }

    public bool Save() {
      return true;
    }
  }
}
