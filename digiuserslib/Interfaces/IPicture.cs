namespace digiuserslib;

public interface IPicture : IInvalid {
  string PictureBase64 { get; }
  string PictureUrl { get; }
}
