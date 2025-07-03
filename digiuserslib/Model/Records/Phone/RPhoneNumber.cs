﻿using System.Text;
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
  public static RPhoneNumber Invalid => new() { Number = string.Empty, Extension = string.Empty };
  public static RPhoneNumber BollyLucOffice => new() { Id = "043308710", CountryCode = EPhoneCountry.Belgium, Prefix = "4", Number = "3308", Extension = "710", Type = EPhoneNumberType.Work };
  public static RPhoneNumber BollyAlainOffice => new() { Id = "0433008374", CountryCode = EPhoneCountry.Belgium, Prefix = "4", Number = "3308", Extension = "374", Type = EPhoneNumberType.Work };
  public static RPhoneNumber BollyLucMobile => new() { Id = "0474960084", CountryCode = EPhoneCountry.Belgium, Prefix = "474", Number = "960084", Type = EPhoneNumberType.Mobile };

  public int Order { get; set; } = 1;
  public EPhoneNumberType Type { get; set; } = EPhoneNumberType.Unknown;
}
