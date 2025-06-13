using System.Reflection.PortableExecutable;

namespace digiusersweb;

internal class TPostRequestMessage : HttpRequestMessage {

  public readonly static string X_DIGIUSERS = "digiusersweb 0.1";

  public TPostRequestMessage(string uri) : base(HttpMethod.Post, uri) {
    Headers.Add("X-digiusers", X_DIGIUSERS);
  }

  public TPostRequestMessage() {
    Method = HttpMethod.Post;
    Headers.Add("X-digiusers", X_DIGIUSERS);
  }

}
