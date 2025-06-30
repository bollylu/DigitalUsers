using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools;

using digiuserslib.Json;

namespace digiuserslib;
public class TDataSourceFile : ADataSource, IDataSource {

  public const string DEFAULT_LOCATION = ".";

  public string DataFileLocation { get; set; } = DEFAULT_LOCATION;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDataSourceFile(string dataFileLocation = DEFAULT_LOCATION) {
    DataFileLocation = dataFileLocation;
    try {
      if (!Directory.Exists(DataFileLocation)) {
        Directory.CreateDirectory(DataFileLocation);
      }
    } catch (Exception ex) {
      throw new ApplicationException($"Unable to create directory {DataFileLocation.WithQuotes()}", ex);
    }
    _Tables.Add(new TTableLocationsFileWithCache(Path.Combine(DataFileLocation, "locations.json")));
  }

  #endregion --- Constructor(s) ------------------------------------------------------------------------------


}
