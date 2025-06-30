namespace digiuserslib;

public record TPicture : ARecord, IPicture {
  public string PictureBase64 { get; set; } = string.Empty;
  public string PictureUrl { get; } = string.Empty;

  public override bool IsInvalid => PictureBase64.Trim() != string.Empty && PictureUrl.Trim() != string.Empty;

}
