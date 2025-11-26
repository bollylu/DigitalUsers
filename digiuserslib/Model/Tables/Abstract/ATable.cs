namespace digiuserslib.Model;

public abstract class ATable : ILoggable, ITable {
  public virtual string Name { get; protected set; } = "";
  public virtual string Description { get; protected set; } = "";

  public ILogger Logger { get; set; } = new TTraceLogger() { Name = nameof(ATable) };

  protected bool _IsInitialized = false;

  protected abstract void Initialize();
}
