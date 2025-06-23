using System.Text.Json.Serialization;

namespace digiuserslib;
public interface IMailAddress : IInvalid {
 
  string Address { get; }
  string DisplayName { get; }

}
