
using System.Text.Json.Serialization;

namespace digiuserslib {
  public interface IInvalid {

    [JsonIgnore]
    bool IsInvalid { get; }

    [JsonIgnore]
    bool IsValid => !IsInvalid;
  }
}
