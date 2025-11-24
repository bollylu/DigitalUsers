using System.Text.Json;
using System.Text.Json.Serialization;

namespace digiuserslib;

public class TTableLocationsFileWithCache : ATableMemory<ILocation> {

  public override string Name { get; protected set; } = nameof(TTableLocationsFileWithCache);
  public override string Description { get; protected set; } = "All locations in a file";

  public const string DEFAULT_DATAFILE = "locations.json";

  public string DataFile { get; set; } = DEFAULT_DATAFILE;

  private readonly JsonSerializerOptions _JsonOptions = new() {
    WriteIndented = true,
    Converters = {
      new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
    },
    IndentSize = 2,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
  };

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TTableLocationsFileWithCache() : base() {
    // Default constructor initializes the data file path
    DataFile = DEFAULT_DATAFILE;
  }

  public TTableLocationsFileWithCache(string dataFile) : this() {
    DataFile = dataFile;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  #region --- I/O --------------------------------------------
  public override async ValueTask<bool> OpenAsync() {
    if (!File.Exists(DataFile)) {
      return false;
    }
    return await ReadAsync();
  }

  public override async ValueTask<bool> CloseAsync() {
    if (IsDirty) { // If the data is dirty, we should save it before closing
      return await SaveAsync();
    }
    return true;
  }

  public async override ValueTask<bool> ReadAsync() {
    try {
      string DataFileContent = await File.ReadAllTextAsync(DataFile);
      _Records.Clear();
      _Records.AddRange(JsonSerializer.Deserialize<List<RLocation>>(DataFileContent, _JsonOptions) ?? []);
      IsDirty = false; // Reset dirty flag after reading
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to read data", ex);
      return false;
    }
  }

  public async override ValueTask<bool> SaveAsync() {
    try {
      await File.WriteAllTextAsync(DataFile, JsonSerializer.Serialize(_Records, _JsonOptions));
      IsDirty = false; // Reset dirty flag after saving
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to save data", ex);
      return false;
    }
  }
  #endregion --- I/O -----------------------------------------
}
