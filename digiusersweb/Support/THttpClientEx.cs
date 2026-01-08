using System.Net;

using BLTools.Core;

namespace digiusersweb;

public class THttpClientEx : HttpClient {
  ILogger Logger { get; }

  public HttpResponseMessage? LastResponse { get; private set; }

  public THttpClientEx()  {
    Logger = new Microsoft.Extensions.Logging.LoggerFactory().CreateLogger<THttpClientEx>();
  }
  public THttpClientEx(ILogger logger) {
    Logger = logger;
  }

  public async Task<string?> GetStringAsync(string request, int timeoutInMs) {

    try {
      Logger.LogDebug($"Request: {request}");

      using (CancellationTokenSource Timeout = new CancellationTokenSource(timeoutInMs)) {

        HttpRequestMessage RequestMessage = new(HttpMethod.Get, request);
        RequestMessage.Headers.Add("Host", Environment.MachineName);
        LastResponse = await GetAsync(request, Timeout.Token).ConfigureAwait(false);
        Logger.LogDebug($"Response: {LastResponse.StatusCode}");
        if (LastResponse.IsSuccessStatusCode) {
          return await LastResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
        } else {
          return null;
        }
      }
    } catch (Exception ex) {
      Logger.LogError($"Unable to read string from client : {ex.Message}");
      if (ex.InnerException is not null) {
        Logger.LogError($"  Inner exception : {ex.InnerException.Message}");
      }
      LastResponse = new HttpResponseMessage(HttpStatusCode.RequestTimeout);
      Logger.LogError($"{(int)LastResponse.StatusCode} : {LastResponse.ReasonPhrase}");
      return null;
    }
  }
    
}

