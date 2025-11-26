namespace digiuserslib.Model;

public interface ITableRecords<T> where T : IRecord {
  T? Get(TKeyId keyId);
  IEnumerable<T> GetAll();

  T? Add(T record);
  T? Update(T record);
  bool Delete(TKeyId keyId);
  bool Delete(T record);
}
