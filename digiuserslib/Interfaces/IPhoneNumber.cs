namespace digiuserslib;
public interface IPhoneNumber {

  string FullPhoneNumber { get; }
  string Number { get; }
  string Prefix { get; }
  string Extension { get; }
  string CountryCode { get; }
}
