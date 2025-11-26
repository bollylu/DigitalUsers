namespace digiuserslib.Model;

public record RMailAddress : ARecord, IMailAddress {
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

  public static RMailAddress Empty => new RMailAddress();
  public static RMailAddress BollyLuc => new RMailAddress() { Address = "l.bolly@seraing.be", DisplayName = "Luc Bolly - IT Manager" };
  public static RMailAddress BollyAlain => new RMailAddress() { Address = "a.bolly@seraing.be", DisplayName = "Alain Bolly - DPO" };
  public static RMailAddress AdamBruno => new RMailAddress() { Address = "b.adam@seraing.be", DisplayName = "Bruno Adam - DG" };
  public static RMailAddress GestionInformatique => new RMailAddress() { Address = "gestion.informatique@seraing.be", DisplayName = "Gestion informatique" };
  public static RMailAddress TravauxInfo => new RMailAddress() { Address = "info.travaux@seraing.be", DisplayName = "Service des travaux - Informations" };
  public static RMailAddress Bourgmestre => new RMailAddress() { Address = "bourgmestre@seraing.be", DisplayName = "Bourgmestre de Seraing" };
}
