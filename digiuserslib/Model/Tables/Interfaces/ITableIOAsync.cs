namespace digiuserslib.Model;

public interface ITableIOAsync : ITable {
  ValueTask<bool> OpenAsync();
  ValueTask<bool> CloseAsync();
  ValueTask<bool> ReadAsync();
  ValueTask<bool> SaveAsync();
}
