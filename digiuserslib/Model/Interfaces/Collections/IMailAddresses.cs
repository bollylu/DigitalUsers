namespace digiuserslib.Model;

public interface IMailAddresses : IList<IMailAddress> {

  IMailAddress? this[string keyId] { get; }

}
