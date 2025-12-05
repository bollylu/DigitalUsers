namespace digiuserslib.Model;

public interface ITableRecords<T> where T : IRecord {
  T? Get(IKeyId keyId);
  IEnumerable<T> GetAll();

  T? Add(T record);
  T? Update(T record);
  bool Delete(IKeyId keyId);
  bool Delete(T record);
}
