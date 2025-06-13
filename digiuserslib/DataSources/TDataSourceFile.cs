
using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools.Diagnostic.Logging;

using digiuserslib.Json;

namespace digiuserslib;
public class TDataSourceFile : ALoggable, IDataSource {

  public const string DEFAULT_DATAFILE = "data.json";
  public string DataFile { get; set; } = DEFAULT_DATAFILE;

  private readonly List<IPerson> _People = [];

  private readonly JsonSerializerOptions _JsonOptions = new() {
    WriteIndented = true,
    Converters = {
      new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
      new TAgentJsonConverter()
    }
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

  public bool Open() {
    if (!File.Exists(DataFile)) {
      return false;
    }
    return true;
  }

  public bool Close() {
    return true;
  }

  public bool Read() {
    try {
      string DataFileContent = File.ReadAllText(DataFile);
      _People.Clear();
      _People.AddRange(JsonSerializer.Deserialize<List<TAgent>>(DataFileContent, _JsonOptions) ?? []);
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to read data", ex);
      return false;
    }
  }

  public bool Save() {
    try {
      using (Stream SaveStream = File.OpenWrite(DataFile)) {
        using (TextWriter SaveWriter = new StreamWriter(SaveStream)) {
          SaveWriter.Write(JsonSerializer.Serialize(_People, _JsonOptions));
          SaveWriter.Flush();
        }
      }
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to save data", ex);
      return false;
    }
  }
}
