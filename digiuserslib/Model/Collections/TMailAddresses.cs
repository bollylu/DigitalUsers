namespace digiuserslib.Model;

public class TMailAddresses : List<IMailAddress>, IMailAddresses {
    public IMailAddress? this[string keyId] => this.FirstOrDefault(p => p.Id.Value.Equals(keyId, StringComparison.OrdinalIgnoreCase));
}
