namespace digiuserslib;

public class TPhoneNumber : IPhoneNumber {

  public string Number { get; set; } = "";
  public string Prefix { get; set; } = "";
  public string Extension { get; set; } = "";
  public string FullPhoneNumber => $"00{CountryCode}-{Prefix}-{Number}-{Extension}";
  public string CountryCode { get; set; } = "32";

  public static TPhoneNumber Empty => new TPhoneNumber();
}
