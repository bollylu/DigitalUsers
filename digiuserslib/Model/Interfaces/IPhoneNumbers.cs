
namespace digiuserslib.Model {
  public interface IPhoneNumbers : IList<IPhoneNumber> {

    IPhoneNumber? MobilePhoneNumber { get; }
    IPhoneNumber? WorkPhoneNumber { get; }
    IPhoneNumber? HomePhoneNumber { get; }

  }
}
