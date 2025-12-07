namespace digiuserslib.Model;

public record RLocation : RLocationBasic, ILocation {

  public IPicture Picture { get; set; } = new RPicture();

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(Name);

  public RLocation() : base() { }
  public RLocation(string id) : base(id) { }
  public RLocation(IKeyId id) : base(id) { }
  public RLocation(ILocationBasic other) : base(other) {
  }
  public RLocation(ILocation other) : base(other.Id) {
    Name = other.Name;
    Address1 = other.Address1;
    Number = other.Number;
    Address2 = other.Address2;
    AddressDetails = other.AddressDetails;
    City = other.City;
    ZipCode = other.ZipCode;
    Country = other.Country;
    Picture = new RPicture(other.Picture);
  }



  public new static RLocation Empty => new();




  public new static RLocation CiteAdministrative => new("cite-administrative") {
    Name = "Cité administrative",
    Address1 = "Place Kuborn, 5",
    ZipCode = "4100",
    City = "Seraing"
  };

  public new static RLocation HotelDeVille => new("hotel-de-ville") {
    Name = "Hôtel de Ville",
    Address1 = "Place communale, 8",
    ZipCode = "4100",
    City = "Seraing"
  };
}