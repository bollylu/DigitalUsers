using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools;

using digiuserslib.Interfaces;

namespace digiuserslib;

public class TTableLocationsWebMemory : ATableWebMemory<ILocation> {
  public override string Name { get; protected set; } = nameof(TTableLocationsWebMemory);
  public override string Description { get; protected set; } = "All locations from a web service";

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TTableLocationsWebMemory() : base() { }
  public TTableLocationsWebMemory(string dataSourceUri) : base(dataSourceUri) { }
  public TTableLocationsWebMemory(Uri dataSourceUri) : base(dataSourceUri) { }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}
