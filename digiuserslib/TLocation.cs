namespace digiuserslib;

public class TLocation : ILocation {

  public const string DEFAULT_COUNTRY = "Belgique";
  public const string DEFAULT_CITY = "Seraing";
  public const string DEFAULT_ZIPCODE = "4100";

  public string Name { get; set; } = string.Empty;
  public string Address1 { get; set; } = string.Empty;
  public string Number { get; set; } = string.Empty;
  public string Address2 { get; set; } = string.Empty;
  public string AddressDetails { get; set; } = string.Empty;
  public string City { get; set; } = DEFAULT_CITY;
  public string ZipCode { get; set; } = DEFAULT_ZIPCODE;
  public string Country { get; set; } = DEFAULT_COUNTRY;

  public static TLocation Empty => new TLocation();
}