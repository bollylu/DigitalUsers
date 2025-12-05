namespace digiuserslib.Model;

public interface ITableRecordsAsync<T> where T : IRecord, ITable {
  Task<T?> GetAsync(IKeyId keyId);
  IAsyncEnumerable<T> GetAllAsync();

  Task<T?> AddAsync(T record);
  Task<T?> UpdateAsync(T record);
  ValueTask<bool> DeleteAsync(IKeyId keyId);
  ValueTask<bool> DeleteAsync(T record);

}
