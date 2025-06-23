namespace digiuserslib;

public class TPicture : IPicture {
  public string PictureBase64 { get; set; } = string.Empty;
  public string PictureUrl { get; } = string.Empty;

  public bool IsInvalid => PictureBase64.Trim() != string.Empty && PictureUrl.Trim() != string.Empty;
}
