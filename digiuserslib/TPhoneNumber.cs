using System.Text;
using System.Text.Json.Serialization;

namespace digiuserslib;

public class TPhoneNumber : IPhoneNumber {

  public string CountryCode { get; set; } = "32";
  public string Prefix { get; set; } = string.Empty;
  public string Number { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;

  [JsonIgnore]
  public string FullPhoneNumber {
    get {
      StringBuilder RetVal = new();
      if (CountryCode == "32") {
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
  public bool IsInvalid => Number.Trim() == string.Empty && Extension.Trim() == string.Empty;

  public static TPhoneNumber Empty => new TPhoneNumber();
}
