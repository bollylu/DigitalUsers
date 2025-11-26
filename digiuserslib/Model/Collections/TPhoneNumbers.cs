namespace digiuserslib.Model;

public class TPhoneNumbers : List<IPhoneNumber>, IPhoneNumbers {

  public IPhoneNumber? MobilePhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Mobile);

  public IPhoneNumber? WorkPhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Work);

  public IPhoneNumber? HomePhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Home);

  public IPhoneNumber? this[string keyId] => this.FirstOrDefault(p => p.Id.Value.Equals(keyId, StringComparison.OrdinalIgnoreCase));
}

