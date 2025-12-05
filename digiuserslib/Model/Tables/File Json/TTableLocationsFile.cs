using System.Text.Json;
using System.Text.Json.Serialization;

namespace digiuserslib;

public class TTableLocationsFile : ATableJsonFileWithCache<ILocation> {

  public const string DEFAULT_DATAFILE = "locations.json";

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TTableLocationsFile() : base() {
    Name = nameof(TTableLocationsFile);
    Description = "All locations in a file";
    DataFile = DEFAULT_DATAFILE;
    Initialize();
  }

  public TTableLocationsFile(string dataFile) : this() {
    DataFile = dataFile;
    Initialize();
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}
