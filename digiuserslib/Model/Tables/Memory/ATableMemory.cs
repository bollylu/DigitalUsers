using BLTools;

namespace digiuserslib;
public abstract class ATableMemory<T> : ATable<T> where T : IRecord {

  protected readonly List<T> _Records = [];
  protected bool IsDirty = false;

  protected ATableMemory() : base() {
  }

  private bool _IsInitialized = false;
  protected override void Initialize() {
    if (_IsInitialized) {
      return;
    }
    base.Initialize();
    Name = $"MemoryTable{typeof(T).Name}";
    Description = $"In-memory table for {typeof(T).Name} records.";
    _IsInitialized = true;
  }

  #region --- I/O --------------------------------------------
  public override bool Open() {
    _Records.Clear();
    IsDirty = false; // Reset dirty state
    return true;
  }

  public override bool Close() {
    _Records.Clear();
    IsDirty = false; // Reset dirty state
    return true;
  }

  public override bool Read() {
    _Records.Clear();
    // Initialize with some dummy data for testing purposes

    IsDirty = false; // Reset dirty state
    return true;
  }

  public override bool Save() {
    IsDirty = false; // Reset dirty state
    return true;
  }
  #endregion --- I/O -----------------------------------------

  #region --- I/O async --------------------------------------------
  public override ValueTask<bool> OpenAsync() {
    _Records.Clear();
    IsDirty = false; // Reset dirty state
    return ValueTask.FromResult(true);
  }

  public override ValueTask<bool> CloseAsync() {
    _Records.Clear();
    IsDirty = false; // Reset dirty state
    return ValueTask.FromResult(true);
  }

  public override ValueTask<bool> ReadAsync() {
    _Records.Clear();
    // Initialize with some dummy data for testing purposes

    IsDirty = false; // Reset dirty state
    return ValueTask.FromResult(true);
  }

  public override ValueTask<bool> SaveAsync() {
    IsDirty = false; // Reset dirty state
    return ValueTask.FromResult(true);
  }
  #endregion --- I/O async -----------------------------------------

  #region --- Records access async --------------------------------------------
  public override Task<T?> GetAsync(TKeyId keyId) {
    return Task.FromResult(_Records.SingleOrDefault(x => x.Id.Value == keyId.Value));
  }

  public override async IAsyncEnumerable<T> GetAllAsync() {
    await Task.Yield();
    foreach (T RecordItem in _Records) {
      yield return RecordItem;
    }
  }

  public override Task<T?> CreateAsync(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid record.");
    }
    if (_Records.Any(x => x.Id == record.Id)) {
      throw new InvalidOperationException($"Record with ID {record.Id.Value.WithQuotes()} already exists.");
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
      throw new KeyNotFoundException($"Record with ID {record.Id.Value.WithQuotes()} not found.");
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
      throw new KeyNotFoundException($"Record with ID {keyId.Value.WithQuotes()} not found.");
    }
    _Records.Remove(ExistingRecord);
    IsDirty = true; // Mark as dirty since we modified the records
    return Task.FromResult(true);
  }

  public override Task<bool> DeleteAsync(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid record.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == record.Id);
    if (ExistingRecord == null) {
      throw new KeyNotFoundException($"Record with ID {record.Id.Value.WithQuotes()} not found.");
    }
    _Records.Remove(ExistingRecord);
    IsDirty = true; // Mark as dirty since we modified the records
    return Task.FromResult(true);
  }
  #endregion --- Records access async -----------------------------------------

  #region --- Records access sync --------------------------------------------
  public override T? Get(TKeyId keyId) {
    return _Records.SingleOrDefault(x => x.Id.Value == keyId.Value);
  }

  public override IEnumerable<T> GetAll() {
    foreach (T RecordItem in _Records) {
      yield return RecordItem;
    }
  }

  public override T? Add(T record) {
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

  public override T? Update(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid record.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == record.Id);
    if (ExistingRecord == null) {
      throw new KeyNotFoundException($"Record with ID {record.Id.Value.WithQuotes()} not found.");
    }
    int Index = _Records.IndexOf(ExistingRecord);
    _Records[Index] = record;
    IsDirty = true; // Mark as dirty since we modified the records
    return record;
  }

  public override bool Delete(TKeyId keyId) {
    if (keyId.IsInvalid) {
      throw new ArgumentException("Invalid key ID.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == keyId);
    if (ExistingRecord == null) {
      throw new KeyNotFoundException($"Record with ID {keyId.Value.WithQuotes()} not found.");
    }
    _Records.Remove(ExistingRecord);
    IsDirty = true; // Mark as dirty since we modified the records
    return true;
  }

  public override bool Delete(T record) {
    if (record.IsInvalid) {
      throw new ArgumentException("Invalid record.");
    }
    T? ExistingRecord = _Records.SingleOrDefault(x => x.Id == record.Id);
    if (ExistingRecord == null) {
      throw new KeyNotFoundException($"Record with ID {record.Id.Value.WithQuotes()} not found.");
    }
    _Records.Remove(ExistingRecord);
    IsDirty = true; // Mark as dirty since we modified the records
    return true;
  }
  #endregion --- Records access sync -----------------------------------------
}
