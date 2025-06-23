
using BLTools.Diagnostic.Logging;

using digiuserslib.DataSources;

namespace digiuserslib {
  public class TDataSourceMemory : ADataSourceWithCache {

    #region --- Constructor(s) ---------------------------------------------------------------------------------
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
        Department = new TDepartment("direction", "Direction"),
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
        Department = new TDepartment("direction", "Direction"),
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
        Department = new TDepartment("direction", "Direction"),
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
        Department = new TDepartment("informatique", "Informatique"),
        SubDepartment = new TDepartment("head", "Head"),
        Title = "Responsable IT",
        DependsOn = "adambr"
      });
      _People.Add(new TAgent("verdial") {
        Name = new TName() { FirstName = "Alain", LastName = "Verdin" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "4", Number = "3308", Extension = "307" },
        EmailPrimary = new TMailAddress() { Address = "a.verdin@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Cité administrative", Address1 = "Place Kuborn, 5", AddressDetails = "5ème étage, Informatique" },
        Company = "Ville de Seraing",
        Department = new TDepartment("informatique", "Informatique"),
        SubDepartment = new TDepartment("support", "Ville"),
        Title = "IT support",
        DependsOn = "bollylu"
      });
      _People.Add(new TAgent("grisfr") {
        Name = new TName() { FirstName = "Frédéric", LastName = "Gris" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "4", Number = "3308", Extension = "308" },
        EmailPrimary = new TMailAddress() { Address = "f.gris@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Cité administrative", Address1 = "Place Kuborn, 5", AddressDetails = "5ème étage, Informatique" },
        Company = "Ville de Seraing",
        Department = new TDepartment("informatique", "Informatique"),
        SubDepartment = new TDepartment("support", "Ville"),
        Title = "IT support",
        DependsOn = "bollylu"
      });
      _People.Add(new TAgent("daglima") {
        Name = new TName() { FirstName = "Maxence", LastName = "D'Agliano" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "4", Number = "3308", Extension = "306" },
        EmailPrimary = new TMailAddress() { Address = "m.dagliano@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Cité administrative", Address1 = "Place Kuborn, 5", AddressDetails = "5ème étage, Informatique" },
        Company = "Ville de Seraing",
        Department = new TDepartment("informatique", "Informatique"),
        SubDepartment = new TDepartment("ecoles", "Ecoles"),
        Title = "IT support",
        DependsOn = "bollylu"
      });
      _People.Add(new TAgent("menarna") {
        Name = new TName() { FirstName = "Nathalie", LastName = "Ménart" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "4", Number = "3308", Extension = "306" },
        EmailPrimary = new TMailAddress() { Address = "n.menart@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Cité administrative", Address1 = "Place Kuborn, 5", AddressDetails = "5ème étage, Informatique" },
        Company = "Ville de Seraing",
        Department = new TDepartment("informatique", "Informatique"),
        SubDepartment = new TDepartment("administratif", "Administratif"),
        Title = "Agent administratif",
        DependsOn = "bollylu"
      });
      _People.Add(new TAgent("bollyal") {
        Name = new TName() { FirstName = "Alain", LastName = "Bolly" },
        PhoneNumberPrimary = new TPhoneNumber() { Prefix = "43", Number = "308", Extension = "586" },
        PhoneNumberMobile = new TPhoneNumber() { Prefix = "470", Number = "123459" },
        EmailPrimary = new TMailAddress() { Address = "a.bolly@seraing.be" },
        WorkLocationPrimary = new TLocation() { Name = "Hôtel de ville", Address1 = "Place xxx,8", AddressDetails = "Rez" },
        Company = "Ville de Seraing",
        Department = new TDepartment("optimisation", "Optimisation"),
        Title = "Responsable optimisation",
        DependsOn = "adambr"
      });
    }
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    #region --- I/O --------------------------------------------
    public override ValueTask<bool> Open() {
      return ValueTask.FromResult(true);
    }

    public override ValueTask<bool> Close() {
      return ValueTask.FromResult(true);
    }

    public override ValueTask<bool> Read() {
      _Initialize();
      return ValueTask.FromResult(true);
    }

    public override ValueTask<bool> Save() {
      return ValueTask.FromResult(true);
    }
    #endregion --- I/O -----------------------------------------
  }
}
