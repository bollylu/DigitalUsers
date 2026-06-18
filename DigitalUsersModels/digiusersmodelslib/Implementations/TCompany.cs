namespace digiusersmodelslib {
  public class TCompany : ARecord, ICompany {
    
    public string Name { get; init; } = string.Empty;

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TCompany() { }
    public TCompany(string name) {
      Name = name;
    } 
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    public static TCompany ACS => new TCompany("ACS");
    public static TCompany Cpas => new TCompany("CPAS");

  }
}
