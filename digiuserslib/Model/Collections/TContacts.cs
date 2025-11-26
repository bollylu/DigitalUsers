namespace digiuserslib.Model {

  public class TContacts : List<IContact>, IContacts {
    public IContact? this[string keyId] => this.FirstOrDefault(p => p.Id.Value.Equals(keyId, StringComparison.OrdinalIgnoreCase));
  }

}
