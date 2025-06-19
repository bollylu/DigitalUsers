using System.Text.Json.Serialization;

namespace digiuserslib;
public interface IPhoneNumber {
  [JsonIgnore]
  string FullPhoneNumber { get; }
  string Number { get; }
  string Prefix { get; }
  string Extension { get; }
  string CountryCode { get; }

  [JsonIgnore]
  bool IsInvalid { get; }
}
