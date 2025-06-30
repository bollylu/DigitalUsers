
using System.Linq;

using BLTools.Diagnostic.Logging;

namespace digiuserslib;

public abstract class ATable : ALoggable, ITable {
  public virtual string Name { get; protected set; } = "";
  public virtual string Description { get; protected set; } = "";

  public abstract ValueTask<bool> Open();
  public abstract ValueTask<bool> Close();
  public abstract ValueTask<bool> Read();
  public abstract ValueTask<bool> Save();
}

//---------------------------------------------------------------------------------------------------------------------------------

public abstract class ATable<T> : ATable, ITable<T> where T : IRecord {
  public abstract Task<T?> GetAsync(TKeyId keyId);
  public abstract IAsyncEnumerable<T> GetAllAsync();
  public abstract Task<T?> CreateAsync(T record);
  public abstract Task<T?> UpdateAsync(T record);
  public abstract Task<bool> DeleteAsync(TKeyId keyId);
  public abstract Task<bool> DeleteAsync(T record);
}

//---------------------------------------------------------------------------------------------------------------------------------


