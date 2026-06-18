namespace digiusersmodelslib;

public abstract class ARecord : IRecord, IInvalid {

  /// <summary>
  /// Gets or sets the ID of the record.
  /// </summary>
  public TKeyId Id { get; init; } = string.Empty;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  protected ARecord() {
  }
  protected ARecord(TKeyId id) {
    Id = id;
  } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  [JsonIgnore]
  public virtual bool IsInvalid => Id.IsInvalid;

}
