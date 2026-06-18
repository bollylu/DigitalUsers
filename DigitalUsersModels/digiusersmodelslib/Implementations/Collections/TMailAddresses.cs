namespace digiusersmodelslib;

public class TMailAddresses : ACollection<IMailAddress>, IMailAddresses {
  public TMailAddresses() : base() { }
  public TMailAddresses(IEnumerable<IMailAddress> collection) : base(collection) { }
}
