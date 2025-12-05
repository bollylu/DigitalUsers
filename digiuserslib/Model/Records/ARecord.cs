namespace digiuserslib.Model;

public abstract record ARecord : IRecord, IInvalid {
  public TKeyId Id { get; set; } = TKeyId.Empty;

  [JsonIgnore]
  public virtual bool IsInvalid => Id.IsInvalid;

}
