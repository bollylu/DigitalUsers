using System.Text.Json.Serialization;

namespace digiuserslib;
public interface IName {
  [JsonIgnore]
  string FullName { get; }
  string FirstName { get; }
  string LastName { get; }

}
