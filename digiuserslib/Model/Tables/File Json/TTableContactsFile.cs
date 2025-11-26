using System.Text.Json;
using System.Text.Json.Serialization;

namespace digiuserslib;

public class TTableContactsFile : ATableJsonFileWithCache<IContact> {

  public const string DEFAULT_DATAFILE = "contacts.json";

  

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TTableContactsFile() : base() {
    Name = nameof(TTableContactsFile);
    Description = "All contact in a file";
    DataFile = DEFAULT_DATAFILE;
  }

  public TTableContactsFile(string dataFile) : this() {
    DataFile = dataFile;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}
