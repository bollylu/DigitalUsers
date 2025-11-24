using System.Text.Json.Serialization;

namespace digiuserslib;
public interface IMailAddress : IRecord, IInvalid {

  string Address { get; }
  string DisplayName { get; }
  int Order { get; }

}
