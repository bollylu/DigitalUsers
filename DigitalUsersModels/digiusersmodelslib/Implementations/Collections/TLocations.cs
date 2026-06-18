namespace digiusersmodelslib;

public class TLocations : ACollection<ILocation>, ILocations {
  public TLocations() : base() { }
  public TLocations(IEnumerable<ILocation> collection) : base(collection) { }
}
