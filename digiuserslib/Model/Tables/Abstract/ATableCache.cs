
namespace digiuserslib.Model;

public abstract class ATableCache<T> : ATable, ITableHandlingAsync, ITableRecords<T> where T : IRecord {

  protected readonly List<T> _Records = [];
  protected bool IsDirty = false;
  protected bool LockTable = false;

  protected ATableCache() : base() {
  }

  protected override void Initialize() {
    if (_IsInitialized) {
      return;
    }
    Name = $"MemoryTable{typeof(T).Name}";
    Description = $"Cache table for {typeof(T).Name} records.";
    _IsInitialized = true;
  }

  public abstract ValueTask<bool> OpenAsync();
  public abstract ValueTask<bool> CloseAsync();
  public abstract ValueTask<bool> ReadAsync();
  public abstract ValueTask<bool> SaveAsync();

  #region --- Records access --------------------------------------------
  public T? Get(TKeyId keyId) {
    return _Records.SingleOrDefault(x => x.Id.Value == keyId.Value);
  }

  public IEnumerable<T> GetAll() {
    foreach (T RecordItem in _Records) {
      yield return RecordItem;
    }
  }

  public T? Add(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid record.");
    }
    if (_Records.Any(x => x.Id == record.Id)) {
      throw new InvalidOperationException($"Record with ID {record.Id.Value.WithQuotes()} already exists.");
    }
    _Records.Add(record);
    IsDirty = true; // Mark as dirty since we modified the records
    return record;
  }

  public T? Update(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid record.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == record.Id) ?? throw new KeyNotFoundException($"Record with ID {record.Id.Value.WithQuotes()} is not found.");
    int Index = _Records.IndexOf(ExistingRecord);
    _Records[Index] = record;
    IsDirty = true; // Mark as dirty since we modified the records
    return record;
  }

  public bool Delete(TKeyId keyId) {
    if (keyId.IsInvalid) {
      throw new ArgumentException("Invalid key ID.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == keyId) ?? throw new KeyNotFoundException($"Record with ID {keyId.Value.WithQuotes()} is not found.");
    _Records.Remove(ExistingRecord);
    IsDirty = true; // Mark as dirty since we modified the records
    return true;
  }

  public bool Delete(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid record.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == record.Id) ?? throw new KeyNotFoundException($"Record with ID {record.Id.Value.WithQuotes()} is not found.");
    _Records.Remove(ExistingRecord);
    IsDirty = true; // Mark as dirty since we modified the records
    return true;
  }

    
    #endregion --- Records access -----------------------------------------
}
