namespace digiuserslib;

public interface IPicture : IRecord, IInvalid {
  string PictureBase64 { get; }
  string PictureUrl { get; }
}
