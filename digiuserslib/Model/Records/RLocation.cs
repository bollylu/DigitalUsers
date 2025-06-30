using System.Text.Json.Serialization;

using Microsoft.Win32.SafeHandles;

namespace digiuserslib;

public record RLocation : ARecord, ILocation {

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
  public override bool IsInvalid => base.IsInvalid || Name.Trim() == string.Empty;

  public static RLocation Empty => new();

  public static RLocation CiteAdministrative => new() {
    Id = "cite-administrative",
    Name = "Cité administrative",
    Address1 = "Place Kuborn, 5",
    ZipCode = "4100",
    City = "Seraing"
  };

  public static RLocation HotelDeVille => new() {
    Id = "hotel-de-ville",
    Name = "Hôtel de Ville",
    Address1 = "Place communale, 8",
    ZipCode = "4100",
    City = "Seraing"
  };
}