using System.Text.Json.Serialization;

namespace digiusersmodelslib;
public interface IName : IInvalid {
 
  [JsonIgnore]
  string FullName { get; }

  string FirstName { get; }
  string LastName { get; }

}
