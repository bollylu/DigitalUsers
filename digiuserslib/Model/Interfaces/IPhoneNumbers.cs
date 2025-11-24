using System.Text.Json.Serialization;

namespace digiuserslib;
public interface IPhoneNumbers {

  IPhoneNumber OfficePhoneNumber { get; }
  IPhoneNumber MobilePhoneNumber { get; }
  IPhoneNumber SecondaryPhoneNumber { get; }

}
