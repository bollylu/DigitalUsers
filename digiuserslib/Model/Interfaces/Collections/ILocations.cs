namespace digiuserslib.Model;

public interface ILocations : IList<ILocation> {

 ILocation? this[string keyId] { get; }

}
