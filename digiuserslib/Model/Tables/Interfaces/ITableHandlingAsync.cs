namespace digiuserslib.Model;

public interface ITableHandlingAsync : ITable {
  ValueTask<bool> OpenAsync();
  ValueTask<bool> CloseAsync();
  ValueTask<bool> ReadAsync();
  ValueTask<bool> SaveAsync();
}
