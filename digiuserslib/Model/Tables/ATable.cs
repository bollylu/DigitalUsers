
using System.Linq;

using BLTools.Diagnostic.Logging;

namespace digiuserslib;

public abstract class ATable : ALoggable, ITable {
  public virtual string Name { get; protected set; } = "";
  public virtual string Description { get; protected set; } = "";

  public abstract bool Open();
  public abstract bool Close();
  public abstract bool Read();
  public abstract bool Save();

  public abstract ValueTask<bool> OpenAsync();
  public abstract ValueTask<bool> CloseAsync();
  public abstract ValueTask<bool> ReadAsync();
  public abstract ValueTask<bool> SaveAsync();
}

//---------------------------------------------------------------------------------------------------------------------------------

public abstract class ATable<T> : ATable, ITable<T> where T : IRecord {
  public abstract Task<T?> GetAsync(TKeyId keyId);
  public abstract IAsyncEnumerable<T> GetAllAsync();
  public abstract Task<T?> CreateAsync(T record);
  public abstract Task<T?> UpdateAsync(T record);
  public abstract Task<bool> DeleteAsync(TKeyId keyId);
  public abstract Task<bool> DeleteAsync(T record);

  public abstract T? Get(TKeyId keyId);
  public abstract IEnumerable<T> GetAll();
  public abstract T? Add(T record);
  public abstract T? Update(T record);
  public abstract bool Delete(TKeyId keyId);
  public abstract bool Delete(T record);
}

//---------------------------------------------------------------------------------------------------------------------------------


