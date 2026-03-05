namespace digiuserslib.Data.Entities;

public class EFContactMailAddress {
  public string ContactId { get; set; } = string.Empty;
  public EFContact Contact { get; set; } = null!;

  public string MailAddressId { get; set; } = string.Empty;
  public EFMailAddress MailAddress { get; set; } = null!;
}