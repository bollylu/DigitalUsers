using Microsoft.Win32.SafeHandles;
using System.Text.Json.Serialization;

namespace digiuserslib;

public record TLocation : ILocation {

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
  public bool IsInvalid => Name.Trim() == string.Empty;

  public static TLocation Empty => new();

  public static TLocation CiteAdministrative => new() {
    Name = "Cité administrative",
    Address1 = "Place Kuborn, 5",
    ZipCode = "4100",
    City = "Seraing"
  };

  public static TLocation HotelDeVille => new() {
    Name = "Hôtel de Ville",
    Address1 = "Place communale, 8",
    ZipCode = "4100",
    City = "Seraing"
  };
}