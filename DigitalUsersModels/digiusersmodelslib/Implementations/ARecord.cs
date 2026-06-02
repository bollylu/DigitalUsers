namespace digiusersmodelslib;

public abstract class ARecord : IRecord, IInvalid {
  public TKeyId Id { get; set; } = string.Empty;

  [JsonIgnore]
  public virtual bool IsInvalid => Id.IsInvalid;

}
