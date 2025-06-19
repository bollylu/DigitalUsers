
using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools.Diagnostic.Logging;

using digiuserslib.Json;

namespace digiuserslib;
public class TDataSourceFile : ALoggable<TDataSourceFile>, IDataSource {

  public const string DEFAULT_DATAFILE = "data.json";
  public string DataFile { get; set; } = DEFAULT_DATAFILE;

  private readonly List<IPerson> _People = [];

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
  public TDataSourceFile(string dataFile = DEFAULT_DATAFILE) {
    DataFile = dataFile;
  }

  public TDataSourceFile(IDataSource dataSource, string dataFile = DEFAULT_DATAFILE) : this(dataFile) {
    foreach (IPerson p in dataSource.GetPeople()) {
      _People.Add(p);
    }
  }



  public IEnumerable<IPerson> GetPeople() {
    return _People;
  }

  public IPerson? GetPerson(string id) {
    return _People.FirstOrDefault(p => p.Id == id);
  }

  public IEnumerable<IPerson> GetPeopleForDepartment(string department) {
    return _People.Where(p => p.Department.Contains(department, StringComparison.CurrentCultureIgnoreCase));
  }

  public IPerson? GetPersonForPhoneNumber(IPhoneNumber phoneNumber) {
    throw new NotImplementedException();
  }

  public IPerson? GetPersonForEmail(IMailAddress mailAddress) {
    throw new NotImplementedException();
  }

  public IEnumerable<IPerson> GetPeopleForLocation(ILocation location) {
    throw new NotImplementedException();
  }

  public ValueTask<bool> Open() {
    if (!File.Exists(DataFile)) {
      return ValueTask.FromResult(false);
    }
    return ValueTask.FromResult(true);
  }

  public ValueTask<bool> Close() {
    return ValueTask.FromResult(true);
  }

  public async ValueTask<bool> Read() {
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

  public async ValueTask<bool> Save() {
    try {
      await File.WriteAllTextAsync(DataFile, JsonSerializer.Serialize(_People, _JsonOptions));
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to save data", ex);
      return false;
    }
  }
}
