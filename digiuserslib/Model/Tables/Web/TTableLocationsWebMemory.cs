namespace digiuserslib.Model;

public class TTableLocationsWebMemory : ATableWeb<ILocation> {
  public override string Name { get; protected set; } = nameof(TTableLocationsWebMemory);
  public override string Description { get; protected set; } = "All locations from a web service";

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TTableLocationsWebMemory() : base() { }
  public TTableLocationsWebMemory(string dataSourceUri) : base(dataSourceUri) { }
  public TTableLocationsWebMemory(Uri dataSourceUri) : base(dataSourceUri) { }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}
