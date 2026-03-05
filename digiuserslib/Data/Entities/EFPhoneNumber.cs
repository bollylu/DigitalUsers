namespace digiuserslib.Data.Entities;

public class EFPhoneNumber {
  public string Id { get; set; } = string.Empty;
  public string Number { get; set; } = string.Empty;
  public EPhoneCountry CountryCode { get; set; } = EPhoneCountry.Belgium;
  public string Prefix { get; set; } = string.Empty;
  public string Extension { get; set; } = string.Empty;
  public EPhoneNumberType Type { get; set; } = EPhoneNumberType.Mobile;
  public ICollection<EFContact> Contacts { get; set; } = [];

}