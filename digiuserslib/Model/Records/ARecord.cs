namespace digiuserslib.Model;

public abstract record ARecord : IRecord, IInvalid {
  public TKeyId Id { get; set; } = TKeyId.Empty;

  protected ARecord() {
  }

  protected ARecord(string id) {
    Id = new TKeyId(id);
  }

  protected ARecord(IKeyId id) {
    Id = new TKeyId(id);
  }

  [JsonIgnore]
  public virtual bool IsInvalid => Id.IsInvalid;

}
