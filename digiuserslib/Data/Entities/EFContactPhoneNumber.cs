namespace digiuserslib.Data.Entities;

public class EFContactPhoneNumber {
  public string ContactId { get; set; } = string.Empty;
  public EFContact Contact { get; set; } = null!;

  public string PhoneNumberId { get; set; } = string.Empty;
  public EFPhoneNumber PhoneNumber { get; set; } = null!;
}