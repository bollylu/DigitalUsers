namespace digiusersmodelslib;

public abstract class ACollection<T> : List<T> where T : IRecord {

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  protected ACollection() {
  }
  protected ACollection(IEnumerable<T> collection) : base(collection) {
  } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public T? this[string keyId] => this.FirstOrDefault(p => p.Id.Value.Equals(keyId, StringComparison.OrdinalIgnoreCase));

}
