namespace digiuserslib.Data.Entities;

public class EFContactLocation {
  public string ContactId { get; set; } = string.Empty;
  public EFContact Contact { get; set; } = null!;

  public string LocationId { get; set; } = string.Empty;
  public EFLocation Location { get; set; } = null!;
}