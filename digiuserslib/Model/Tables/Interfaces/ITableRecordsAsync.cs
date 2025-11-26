namespace digiuserslib.Model;

public interface ITableRecordsAsync<T> where T : IRecord, ITable {
  Task<T?> GetAsync(TKeyId keyId);
  IAsyncEnumerable<T> GetAllAsync();

  Task<T?> AddAsync(T record);
  Task<T?> UpdateAsync(T record);
  ValueTask<bool> DeleteAsync(TKeyId keyId);
  ValueTask<bool> DeleteAsync(T record);

}
