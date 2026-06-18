namespace digiusersmodelslib;

public class TPhoneNumber : ARecord, IPhoneNumber {

  public EPhoneCountry CountryCode { get; set; } = EPhoneCountry.Belgium;
  public string Prefix { get; set; } = string.Empty;
  public string Number { get; set; } = string.Empty;
  public string Extension { get; set; } = string.Empty;
  public int Order { get; set; } = 1;
  public EPhoneNumberType Type { get; set; } = EPhoneNumberType.Unknown;

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
  public override bool IsInvalid => base.IsInvalid || (string.IsNullOrWhiteSpace(Number) && string.IsNullOrWhiteSpace(Extension));

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TPhoneNumber() : base() { }
  public TPhoneNumber(TKeyId id) : base(id) { }
  public TPhoneNumber(IPhoneNumber phoneNumber) : base(phoneNumber.Id) {
    CountryCode = phoneNumber.CountryCode;
    Prefix = phoneNumber.Prefix;
    Number = phoneNumber.Number;
    Extension = phoneNumber.Extension;
    Order = phoneNumber.Order;
    Type = phoneNumber.Type;
  } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public static TPhoneNumber Empty => new();
  public static TPhoneNumber Invalid => new() { Number = string.Empty, Extension = string.Empty };
  public static TPhoneNumber ItOffice => new("32020833710") { CountryCode = EPhoneCountry.Belgium, Prefix = "2", Number = "0833", Extension = "710", Type = EPhoneNumberType.Work };
  public static TPhoneNumber DpoOffice => new("32023308374") { CountryCode = EPhoneCountry.Belgium, Prefix = "2", Number = "0833", Extension = "374", Type = EPhoneNumberType.Work };
  public static TPhoneNumber ItManagerMobile => new("320479980184") { CountryCode = EPhoneCountry.Belgium, Prefix = "479", Number = "980184", Type = EPhoneNumberType.Mobile };

}
