
namespace digiusersmodelslib;

public interface IContacts : IList<IContact> {

  IContact? this[string keyId] { get; }

}


