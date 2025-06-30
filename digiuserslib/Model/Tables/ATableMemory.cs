namespace digiuserslib;
public abstract class ATableMemory<T> : ATable<T> where T : IRecord {

  protected readonly List<T> _Records = [];
  protected bool IsDirty = false;

  protected ATableMemory() {
    _Initialize();
  }

  protected virtual void _Initialize() { }

  #region --- I/O --------------------------------------------
  public override ValueTask<bool> Open() {
    _Records.Clear();
    IsDirty = false; // Reset dirty state
    return ValueTask.FromResult(true);
  }

  public override ValueTask<bool> Close() {
    _Records.Clear();
    IsDirty = false; // Reset dirty state
    return ValueTask.FromResult(true);
  }

  public override ValueTask<bool> Read() {
    _Records.Clear();
    // Initialize with some dummy data for testing purposes

    IsDirty = false; // Reset dirty state
    return ValueTask.FromResult(true);
  }

  public override ValueTask<bool> Save() {
    IsDirty = false; // Reset dirty state
    return ValueTask.FromResult(true);
  }
  #endregion --- I/O -----------------------------------------

  #region --- Records access --------------------------------------------
  public override Task<T?> GetAsync(TKeyId keyId) {
    return Task.FromResult(_Records.SingleOrDefault(x => x.Id == keyId));
  }

  public override async IAsyncEnumerable<T> GetAllAsync() {
    await Task.Yield();
    foreach (T LocationItem in _Records) {
      yield return LocationItem;
    }
  }

  public override Task<T?> CreateAsync(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid location record.");
    }
    if (_Records.Any(x => x.Id == record.Id)) {
      throw new InvalidOperationException($"Location with ID {record.Id} already exists.");
    }
    _Records.Add(record);
    IsDirty = true; // Mark as dirty since we modified the records
    return Task.FromResult<T?>(record);
  }

  public override Task<T?> UpdateAsync(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid record.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == record.Id);
    if (ExistingRecord == null) {
      throw new KeyNotFoundException($"Record with ID {record.Id} not found.");
    }
    int Index = _Records.IndexOf(ExistingRecord);
    _Records[Index] = record;
    IsDirty = true; // Mark as dirty since we modified the records
    return Task.FromResult<T?>(record);
  }

  public override Task<bool> DeleteAsync(TKeyId keyId) {
    if (keyId.IsInvalid) {
      throw new ArgumentException("Invalid key ID.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == keyId);
    if (ExistingRecord == null) {
      throw new KeyNotFoundException($"Location with ID {keyId} not found.");
    }
    _Records.Remove(ExistingRecord);
    IsDirty = true; // Mark as dirty since we modified the records
    return Task.FromResult(true);
  }

  public override Task<bool> DeleteAsync(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid location record.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == record.Id);
    if (ExistingRecord == null) {
      throw new KeyNotFoundException($"Location with ID {record.Id} not found.");
    }
    _Records.Remove(ExistingRecord);
    IsDirty = true; // Mark as dirty since we modified the records
    return Task.FromResult(true);
  }
  #endregion --- Records access -----------------------------------------

}
