namespace digiusersmodelslib {
  public class TCompany : ARecord, ICompany {
    
    public string Name { get; init; } = string.Empty;

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TCompany() : base() { }
    public TCompany(string name) : base() {
      Name = name;
    }
    public TCompany(TKeyId id, string name) : base(id) {
      Name = name;
    } 
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    public TCompany(ICompany company) : base(company.Id) {
      Name = company.Name;
    }
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    public static TCompany ACS => new TCompany("AC Ville");
    public static TCompany CPAS => new TCompany("CPAS de la ville");

  }
}
