using System.Text.Json.Serialization;

namespace digiuserslib;

public record RPicture : ARecord, IPicture {
  public string PictureBase64 { get; init; } = string.Empty;
  public string PictureUrl { get; init; } = string.Empty;

  [JsonIgnore]
  public override bool IsInvalid => PictureBase64.Trim() != string.Empty && PictureUrl.Trim() != string.Empty;

  public RPicture() { }
  public RPicture(string pictureBase64) {
    PictureBase64 = pictureBase64;
  }
  public RPicture(byte[] pictureBytes) {
    PictureBase64 = Convert.ToBase64String(pictureBytes);
  }
  
  public byte[]? GetPictureBytes() {
    if (string.IsNullOrEmpty(PictureBase64)) {
      return null;
    }
    try {
      return Convert.FromBase64String(PictureBase64);
    } catch (FormatException) {
      return null; // Invalid Base64 string
    }
  }

}
