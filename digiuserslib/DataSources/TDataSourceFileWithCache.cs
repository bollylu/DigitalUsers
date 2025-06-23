
using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools.Diagnostic.Logging;

using digiuserslib.DataSources;
using digiuserslib.Json;

namespace digiuserslib;
public class TDataSourceFileWithCache : ADataSourceWithCache, IDataSource {

  public const string DEFAULT_DATAFILE = "data.json";
  public string DataFile { get; set; } = DEFAULT_DATAFILE;

  private readonly JsonSerializerOptions _JsonOptions = new() {
    WriteIndented = true,
    Converters = {
      new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
      new TAgentJsonConverter()
    },
    IndentSize = 2,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
  };

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDataSourceFileWithCache(string dataFile = DEFAULT_DATAFILE) {
    DataFile = dataFile;
  }

  public TDataSourceFileWithCache(IDataSource dataSource, string dataFile = DEFAULT_DATAFILE) : this(dataFile) {
    foreach (IPerson p in dataSource.GetPeople()) {
      _People.Add(p);
    }
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  #region --- I/O --------------------------------------------
  public override ValueTask<bool> Open() {
    if (!File.Exists(DataFile)) {
      return ValueTask.FromResult(false);
    }
    return ValueTask.FromResult(true);
  }

  public override ValueTask<bool> Close() {
    return ValueTask.FromResult(true);
  }

  public override async ValueTask<bool> Read() {
    try {
      string DataFileContent = await File.ReadAllTextAsync(DataFile);
      _People.Clear();
      _People.AddRange(JsonSerializer.Deserialize<List<TAgent>>(DataFileContent, _JsonOptions) ?? []);
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to read data", ex);
      return false;
    }
  }

  public override async ValueTask<bool> Save() {
    try {
      await File.WriteAllTextAsync(DataFile, JsonSerializer.Serialize(_People, _JsonOptions));
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to save data", ex);
      return false;
    }
  }
  #endregion --- I/O -----------------------------------------
}
