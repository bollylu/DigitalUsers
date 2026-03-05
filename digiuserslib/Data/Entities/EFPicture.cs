namespace digiuserslib.Data.Entities;

public class EFPicture {
  public string Id { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string PictureBase64 { get; set; } = string.Empty;
  public string PictureUrl { get; set; } = string.Empty;

  public string? ContactId { get; set; }
  public string? LocationId { get; set; }

  
}