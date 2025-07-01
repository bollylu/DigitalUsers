using System.Text.Json.Serialization;

namespace digiuserslib;
public interface IPhoneNumber : IRecord, IInvalid {

  int Order { get; }

  string Number { get; }
  string Prefix { get; }
  string Extension { get; }
  EPhoneCountry CountryCode { get; }
  EPhoneNumberType Type { get; }

  [JsonIgnore]
  string FullPhoneNumber { get; }

}
