
using System.Text.Json.Serialization;

namespace digiusersmodelslib {
  public interface IInvalid {

    [JsonIgnore]
    bool IsInvalid { get; }

    [JsonIgnore]
    bool IsValid => !IsInvalid;
  }
}
