namespace digiuserslib.Model;

public interface IPhoneNumber : IRecord, IInvalid {

  int Order { get; }

  string Number { get; }
  string Prefix { get; }
  string Extension { get; }
  EPhoneCountry CountryCode { get; }
  EPhoneNumberType Type { get; }

  string FullPhoneNumber { get; }

}
