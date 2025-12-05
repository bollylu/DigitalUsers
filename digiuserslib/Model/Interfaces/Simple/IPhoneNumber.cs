namespace digiuserslib.Model;

public interface IPhoneNumber : IRecord, IInvalid {

  string Number { get; }
  string Prefix { get; }
  string Extension { get; }
  EPhoneCountry CountryCode { get; }
  EPhoneNumberType Type { get; }

  [JsonIgnore]
  string FullPhoneNumber { get; }

}
