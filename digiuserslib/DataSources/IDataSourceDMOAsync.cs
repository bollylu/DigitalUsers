namespace digiuserslib;

public interface IDataSourceDMOAsync {

  #region --- I/O async --------------------------------------------
  
  ValueTask<bool> OpenAsync();
  ValueTask<bool> CloseAsync();
  
  #endregion --- I/O async -----------------------------------------
  
}
