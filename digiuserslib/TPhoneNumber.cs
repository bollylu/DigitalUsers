using System.Text.Json.Serialization;

namespace digiuserslib;

public class TPhoneNumber : IPhoneNumber {

  public string CountryCode { get; set; } = "32";
  public string Number { get; set; } = string.Empty;
  public string Prefix { get; set; } = string.Empty;
  public string Extension { get; set; } = string.Empty;

  [JsonIgnore]
  public string FullPhoneNumber => $"00{CountryCode}-{Prefix}-{Number}-{Extension}";
  

  [JsonIgnore]
  public bool IsInvalid => Number.Trim() == string.Empty && Extension.Trim() == string.Empty;

  public static TPhoneNumber Empty => new TPhoneNumber();
}
