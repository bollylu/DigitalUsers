using System.Text.Json.Serialization;

namespace digiuserslib;
public interface IPhoneNumber : IInvalid {
  [JsonIgnore]
  string FullPhoneNumber { get; }

  string Number { get; }
  string Prefix { get; }
  string Extension { get; }
  string CountryCode { get; }

}
