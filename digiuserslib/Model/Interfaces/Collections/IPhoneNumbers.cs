
namespace digiuserslib.Model {
  public interface IPhoneNumbers : IList<IPhoneNumber> {

    IPhoneNumber? this[string keyId] { get; }

    IPhoneNumber? MobilePhoneNumber { get; }
    IPhoneNumber? WorkPhoneNumber { get; }
    IPhoneNumber? HomePhoneNumber { get; }

  }
}
