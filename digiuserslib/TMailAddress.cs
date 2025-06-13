namespace digiuserslib;

public class TMailAddress : IMailAddress {
  public string Address { get; set; } = "";
  public string DisplayName { get; set; } = "";

  public static TMailAddress Empty => new TMailAddress();
}
