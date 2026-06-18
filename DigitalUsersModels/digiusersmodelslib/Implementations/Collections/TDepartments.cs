namespace digiusersmodelslib;

public class TDepartments : ACollection<IDepartment>, IDepartments {

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDepartments() : base() { }
  public TDepartments(IEnumerable<IDepartment> collection) : base(collection) { } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  [JsonIgnore]
  public IDepartment Main => this.FirstOrDefault() ?? throw new InvalidOperationException("No main department found.");

}

