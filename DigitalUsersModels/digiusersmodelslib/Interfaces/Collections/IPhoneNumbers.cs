
namespace digiusersmodelslib {
  public interface IPhoneNumbers : ICollection<IPhoneNumber> {

    IPhoneNumber? MobilePhoneNumber { get; }
    IPhoneNumber? WorkPhoneNumber { get; }
    IPhoneNumber? HomePhoneNumber { get; }

  }
}
