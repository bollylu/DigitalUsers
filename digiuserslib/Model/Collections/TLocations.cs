namespace digiuserslib.Model;

public class TLocations : List<ILocation>, ILocations {
    public ILocation? this[string keyId] => this.FirstOrDefault(p => p.Id.Value.Equals(keyId, StringComparison.OrdinalIgnoreCase));
}
