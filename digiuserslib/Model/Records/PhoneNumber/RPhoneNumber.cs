namespace digiuserslib.Model;

public record RPhoneNumber : ARecord, IPhoneNumber {

  public EPhoneCountry CountryCode { get; set; } = EPhoneCountry.Belgium;
  public string Prefix { get; set; } = string.Empty;
  public string Number { get; set; } = string.Empty;
  public string Extension { get; set; } = string.Empty;
  public EPhoneNumberType Type { get; set; } = EPhoneNumberType.Unknown;

  [JsonIgnore]
  public string FullPhoneNumber {
    get {
      StringBuilder RetVal = new("+");
      RetVal.Append(CountryCode);

      if (Prefix.Trim() != string.Empty) {
        RetVal.Append(Prefix.Trim());
      }

      if (Number.Trim() != string.Empty) {
        RetVal.Append(Number.Trim());
      }

      if (Extension.Trim() != string.Empty) {
        RetVal.Append(Extension.Trim());
      }
      return RetVal.ToString();
    }
  }

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || (string.IsNullOrWhiteSpace(Number) && string.IsNullOrWhiteSpace(Extension));

  #region --- Constructor(s) --------------------------------------------------
  public RPhoneNumber() {
  }
  public RPhoneNumber(string id) : base(id) {
  }
  public RPhoneNumber(IKeyId id) : base(id) {
  }

  public RPhoneNumber(IPhoneNumber other) : base(other.Id) {
    CountryCode = other.CountryCode;
    Prefix = other.Prefix;
    Number = other.Number;
    Extension = other.Extension;
    Type = other.Type;
  }
  #endregion ------------------------------------------------------------------



  public static RPhoneNumber Empty => new();
  public static RPhoneNumber Invalid => new() { Number = string.Empty, Extension = string.Empty };
  public static RPhoneNumber BollyLucOffice => new("+3243308710") { CountryCode = EPhoneCountry.Belgium, Prefix = "4", Number = "3308", Extension = "710", Type = EPhoneNumberType.Work };
  public static RPhoneNumber BollyAlainOffice => new("+32433008374") { CountryCode = EPhoneCountry.Belgium, Prefix = "4", Number = "3308", Extension = "374", Type = EPhoneNumberType.Work };
  public static RPhoneNumber BollyLucMobile => new("+32474960084") { CountryCode = EPhoneCountry.Belgium, Prefix = "474", Number = "960084", Type = EPhoneNumberType.Mobile };

}
