using System.Collections.Generic;

namespace digiuserslib.Model;

public abstract class ATableJsonFileWithCache<T> : ATableCache<T> where T : IRecord {
  
  [JsonIgnore]
  public string DataFile { get; set; } = string.Empty;

  [JsonIgnore]
  protected JsonSerializerOptions _JsonOptions = new() {
    WriteIndented = true,
    //Converters = {
    //  new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
    //},
    IndentSize = 2,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
  };

  protected ATableJsonFileWithCache() : base() {
    Initialize();
  }

  #region --- I/O --------------------------------------------
  public override async ValueTask<bool> OpenAsync() {
    try {
      if (!File.Exists(DataFile)) {
        return false;
      }
      if (LockTable) {
        Logger.LogWarningBox("Table is locked, cannot open at this time.", Name);
        return false;
      }
      return await ReadAsync();
    } finally {
      LockTable = false; // Always unlock the table after operation
    }
  }

  public override async ValueTask<bool> CloseAsync() {
    try {
      if (LockTable) {
        Logger.LogWarningBox("Table is locked, cannot close at this time.", Name);
        return false;
      }
      if (IsDirty) { // If the data is dirty, we should save it before closing
        return await SaveAsync();
      }
      return true;
    } finally {
      LockTable = false; // Always unlock the table after operation
    }
  }

  public async override ValueTask<bool> ReadAsync() {
    try {
      if (LockTable) {
        Logger.LogWarningBox("Table is locked, cannot read at this time.", Name);
        return false;
      }
      LockTable = true; // Lock the table to prevent modifications during read
      string DataFileContent = await File.ReadAllTextAsync(DataFile);
      _Records.Clear();
      _Records.AddRange(JsonSerializer.Deserialize<List<T>>(DataFileContent, _JsonOptions) ?? []);
      IsDirty = false; // Reset dirty flag after reading
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to read data", ex);
      return false;
    } finally {
      LockTable = false; // Always unlock the table after operation
    }
  }

  public async override ValueTask<bool> SaveAsync() {
    try {
      if (LockTable) {
        Logger.LogWarningBox("Table is locked, cannot save at this time.", Name);
        return false;
      }
      LockTable = true; // Lock the table to prevent modifications during save
      await File.WriteAllTextAsync(DataFile, JsonSerializer.Serialize(_Records, _JsonOptions));
      IsDirty = false; // Reset dirty flag after saving
      return true;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to save data", ex);
      return false;
    } finally {
      LockTable = false; // Always unlock the table after operation
    }
  }
  #endregion --- I/O -----------------------------------------

}
