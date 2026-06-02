namespace digiusersmodelslib;

public class TMailAddress : ARecord, IMailAddress {
  public string Address { get; set; } = string.Empty;
  public string DisplayName { get; set; } = string.Empty;
  public int Order { get; set; } = 1;

  [JsonIgnore]
  public override bool IsInvalid =>
    base.IsInvalid ||
    string.IsNullOrWhiteSpace(Address) ||
    !Address.Contains('@') ||
    Address.Count('@') > 1 ||
    !Address.Contains('.') ||
    string.IsNullOrEmpty(Address.Before('@')) ||
    string.IsNullOrWhiteSpace(Address.After('.')) ||
    string.IsNullOrWhiteSpace(Address.Between('@', '.'));

  public static TMailAddress Empty => new TMailAddress();
  public static TMailAddress BollyLuc => new TMailAddress() { Address = "l.bolly@seraing.be", DisplayName = "Luc Bolly - IT Manager" };
  public static TMailAddress BollyAlain => new TMailAddress() { Address = "a.bolly@seraing.be", DisplayName = "Alain Bolly - DPO" };
  public static TMailAddress AdamBruno => new TMailAddress() { Address = "b.adam@seraing.be", DisplayName = "Bruno Adam - DG" };
  public static TMailAddress GestionInformatique => new TMailAddress() { Address = "gestion.informatique@seraing.be", DisplayName = "Gestion informatique" };
  public static TMailAddress TravauxInfo => new TMailAddress() { Address = "info.travaux@seraing.be", DisplayName = "Service des travaux - Informations" };
  public static TMailAddress Bourgmestre => new TMailAddress() { Address = "bourgmestre@seraing.be", DisplayName = "Bourgmestre de Seraing" };
}
