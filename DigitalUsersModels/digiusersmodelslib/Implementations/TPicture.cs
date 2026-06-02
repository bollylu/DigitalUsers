namespace digiusersmodelslib;

public class TPicture : ARecord, IPicture, ILoggable {
  
  [JsonIgnore]
  public ILogger Logger { get; set; } = new TTraceLogger() { Name = nameof(TPicture) };

  public string Name { get; init; } = string.Empty;
  public string PictureBase64 { get; init; } = string.Empty;
  public string PictureUrl { get; init; } = string.Empty;

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || (string.IsNullOrWhiteSpace(PictureBase64) && string.IsNullOrWhiteSpace(PictureUrl));

  public TPicture() { }
  public TPicture(string pictureBase64) {
    PictureBase64 = pictureBase64;
  }
  public TPicture(byte[] pictureBytes) {
    PictureBase64 = Convert.ToBase64String(pictureBytes);
  }

  public byte[]? GetPictureBytes() {
    if (string.IsNullOrEmpty(PictureBase64)) {
      return null;
    }
    try {
      return Convert.FromBase64String(PictureBase64);
    } catch (FormatException ex) {
      Logger.LogErrorBox("Invalid Base64 string in PictureBase64", ex);
      return null; // Invalid Base64 string
    }
  }


}
