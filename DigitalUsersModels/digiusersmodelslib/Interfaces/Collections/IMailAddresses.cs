namespace digiusersmodelslib;

public interface IMailAddresses : IList<IMailAddress> {

  IMailAddress? this[string keyId] { get; }

}
