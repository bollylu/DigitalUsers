namespace digiusersweb;

internal class TGetRequestMessage : HttpRequestMessage {

  public readonly static string X_DIGIUSERS = "digiusers 0.1";

  public TGetRequestMessage(string uri) {
    Method = HttpMethod.Get;
    RequestUri = new Uri(uri, UriKind.Relative);
    Headers.Add("X-digiusers", X_DIGIUSERS);
  }

  public TGetRequestMessage() {
    Method = HttpMethod.Get;
    Headers.Add("X-digiusers", X_DIGIUSERS);
  }
}
