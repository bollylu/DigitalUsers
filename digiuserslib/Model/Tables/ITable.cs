using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digiuserslib;

public interface ITable {
  string Name { get; }
  string Description { get; }

  #region --- I/O sync --------------------------------------------
  bool Open();
  bool Close();
  bool Read();
  bool Save();
  #endregion --- I/O async -----------------------------------------

  #region --- I/O async --------------------------------------------
  ValueTask<bool> OpenAsync();
  ValueTask<bool> CloseAsync();
  ValueTask<bool> ReadAsync();
  ValueTask<bool> SaveAsync();
  #endregion --- I/O async -----------------------------------------
}

public interface ITable<T> : ITable where T : IRecord {
  Task<T?> GetAsync(TKeyId keyId);
  IAsyncEnumerable<T> GetAllAsync();

  Task<T?> CreateAsync(T record);
  Task<T?> UpdateAsync(T record);
  Task<bool> DeleteAsync(TKeyId keyId);
  Task<bool> DeleteAsync(T record);

  T? Get(TKeyId keyId);
  IEnumerable<T> GetAll();

  T? Create(T record);
  T? Update(T record);
  bool Delete(TKeyId keyId);
  bool Delete(T record);
}
