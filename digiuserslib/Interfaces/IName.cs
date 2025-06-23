using System.Text.Json.Serialization;

namespace digiuserslib;
public interface IName : IInvalid {
 
  [JsonIgnore]
  string FullName { get; }

  string FirstName { get; }
  string LastName { get; }

}
