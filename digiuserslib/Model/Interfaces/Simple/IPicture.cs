namespace digiuserslib.Model;

public interface IPicture : IRecord, IInvalid {
  string Name { get; }

  string PictureBase64 { get; }
  string PictureUrl { get; }

  byte[]? GetPictureBytes();
}
