namespace digiusersmodelslib {
  public class TCompany : ARecord, ICompany {
    
    public string Name { get; init; } = string.Empty;

    public TCompany() { }
    public TCompany(string name) {
      Name = name;
    }

    public static TCompany AcSeraing => new TCompany("AC Seraing");
    public static TCompany CpasSeraing => new TCompany("CPAS Seraing");

  }
}
