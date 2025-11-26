
namespace digiuserslib;

public abstract class ADataSourceDMOAsync : IDataSourceDMOAsync {
  public ILogger Logger { get; set; } = new TTraceLogger();

  protected readonly List<ITable> _Tables = [];

  public abstract ValueTask<bool> OpenAsync();
  public abstract ValueTask<bool> CloseAsync();

}
