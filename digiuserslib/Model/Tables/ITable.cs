using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digiuserslib;

public interface ITable {
  string Name { get; }
  string Description { get; }

  #region --- I/O --------------------------------------------
  ValueTask<bool> Open();
  ValueTask<bool> Close();

  ValueTask<bool> Read();
  ValueTask<bool> Save();
  #endregion --- I/O -----------------------------------------
}

public interface ITable<T> : ITable where T : IRecord {
  Task<T?> GetAsync(TKeyId keyId);
  IAsyncEnumerable<T> GetAllAsync();

  Task<T?> CreateAsync(T record);
  Task<T?> UpdateAsync(T record);
  Task<bool> DeleteAsync(TKeyId keyId);
  Task<bool> DeleteAsync(T record);
}
