using System.Text;
using System.Text.Json.Serialization;

namespace digiuserslib;

public record RPhoneNumber : ARecord, IPhoneNumber {

  public EPhoneCountry CountryCode { get; set; } = EPhoneCountry.Belgium;
  public string Prefix { get; set; } = string.Empty;
  public string Number { get; set; } = string.Empty;
  public string Extension { get; set; } = string.Empty;

  [JsonIgnore]
  public string FullPhoneNumber {
    get {
      StringBuilder RetVal = new();
      if (CountryCode == EPhoneCountry.Belgium) {
        RetVal.Append('0');
        if (Prefix.Trim() != string.Empty) {
          RetVal.Append(Prefix.Trim());
        }
      } else {
        RetVal.Append($"00{CountryCode}");
        if (Prefix.Trim() != string.Empty) {
          RetVal.Append('-');
          RetVal.Append(Prefix.Trim());
        }
      }

      if (Number.Trim() != string.Empty) {
        RetVal.Append('/');
        RetVal.Append(Number.Trim());
      }

      if (Extension.Trim() != string.Empty) {
        RetVal.Append('.');
        RetVal.Append(Extension.Trim());
      }
      return RetVal.ToString();
    }
  }

  [JsonIgnore]
  public override bool IsInvalid => Number.Trim() == string.Empty && Extension.Trim() == string.Empty;

  public static RPhoneNumber Empty => new();

  public int Order { get; set; } = 1;
  public EPhoneNumberType Type { get; set; } = EPhoneNumberType.Unknown;
}
