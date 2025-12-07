namespace digiuserslib.Model;

public record RLocationBasic : ARecord, ILocationBasic {

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

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(Name);

  public RLocationBasic() : base() { }
  public RLocationBasic(string id) : base(id) { }
  public RLocationBasic(IKeyId id) : base(id) { }
  public RLocationBasic(ILocationBasic other) : base(other.Id) {
    Name = other.Name;
    Address1 = other.Address1;
    Number = other.Number;
    Address2 = other.Address2;
    AddressDetails = other.AddressDetails;
    City = other.City;
    ZipCode = other.ZipCode;
    Country = other.Country;
  }



  public static RLocationBasic Empty => new();

  public static RLocationBasic CiteAdministrative => new("cite-administrative") {
    Name = "Cité administrative",
    Address1 = "Place Kuborn, 5",
    ZipCode = "4100",
    City = "Seraing"
  };

  public static RLocationBasic HotelDeVille => new("hotel-de-ville") {
    Name = "Hôtel de Ville",
    Address1 = "Place communale, 8",
    ZipCode = "4100",
    City = "Seraing"
  };
}