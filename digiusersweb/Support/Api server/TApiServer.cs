﻿using System.Net;
using System.Text;

using BLTools;
using BLTools.Diagnostic.Logging;

namespace digiusersweb;

public class TApiServer : ALoggable, IApiServer {

  private readonly HttpClient _HttpClient = new HttpClient() { };
  public HttpResponseMessage? LastResponse { get; private set; }

  public Uri BaseAddress => _HttpClient?.BaseAddress ?? new Uri("http://localhost:1234");
  public int RequestId { get; private set; } = 0;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TApiServer() {
    Logger = new TConsoleLogger<TApiServer>();
    Logger.SeverityLimit = ESeverity.DebugEx;
  }

  public TApiServer(Uri baseAddress) : this() {
    Logger.LogDebug($"New TApiServer {baseAddress}");
    _HttpClient.BaseAddress = baseAddress;
  }

  public TApiServer(string baseAddress) : this() {
    Logger.LogDebug($"New TApiServer {baseAddress}");
    _HttpClient.BaseAddress = new Uri(baseAddress);
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  public override string ToString() {
    StringBuilder RetVal = new StringBuilder();
    RetVal.Append($"ApiServer : {BaseAddress.ToString().WithQuotes()}");
    RetVal.Append($", Last response : {LastResponse?.StatusCode.ToString() ?? "(none)"}");
    return RetVal.ToString();
  }

  //#region --- Get Json --------------------------------------------
  //public async Task<T?> GetJsonAsync<T>(string uriRequest, CancellationToken cancellationToken) where T : class, IJson<T> {
  //  int LocalRequestId = ++RequestId;

  //  try {

  //    TGetRequestMessage RequestMessage = new TGetRequestMessage(uriRequest);
  //    Logger.LogDebugExBox($"Request #{LocalRequestId}", uriRequest);

  //    LastResponse = await _HttpClient.SendAsync(RequestMessage, cancellationToken).ConfigureAwait(false);
  //    if (!LastResponse.IsSuccessStatusCode) {
  //      Logger.LogDebugExBox($"Response #{LocalRequestId} : {LastResponse.StatusCode}", await LastResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
  //      return default;
  //    }

  //    string StringContent = await LastResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
  //    T? JsonContent = IJson<T>.FromJson(StringContent);

  //    Logger.LogDebugExBox($"Response #{LocalRequestId} : {LastResponse.StatusCode}", StringContent);

  //    return JsonContent;

  //  } catch (Exception ex) {
  //    Logger.LogErrorBox($"Unable to read string from client request #{LocalRequestId}", ex);
  //    if (ex.InnerException is not null) {
  //      Logger.LogErrorBox($"  Inner exception", ex.InnerException);
  //    }

  //    LastResponse = new HttpResponseMessage(HttpStatusCode.RequestTimeout);

  //    Logger.LogErrorBox($"{(int)LastResponse.StatusCode}", LastResponse.ReasonPhrase ?? "(null)");
  //    return default;
  //  }
  //}

  //public async Task<T?> GetJsonAsync<C, T>(string uriRequest, IJson<C> additionalContent, CancellationToken cancellationToken) where T : class, IJson<T> where C : class, IJson<C> {
  //  int LocalRequestId = ++RequestId;

  //  try {

  //    TPostRequestMessage RequestMessage = new TPostRequestMessage(uriRequest);
  //    RequestMessage.Content = new StringContent(additionalContent.ToJson());
  //    RequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

  //    Logger.LogDebugExBox($"Request #{LocalRequestId} : {uriRequest} - Content is {additionalContent.GetType().Name}", additionalContent);

  //    LastResponse = await _HttpClient.SendAsync(RequestMessage, cancellationToken).ConfigureAwait(false);
  //    if (!LastResponse.IsSuccessStatusCode) {
  //      Logger.LogDebugExBox($"Response #{LocalRequestId} : {LastResponse.StatusCode}", await LastResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
  //      return default;
  //    }

  //    string StringContent = await LastResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
  //    T? JsonContent = IJson<T>.FromJson(StringContent);

  //    Logger.LogDebugExBox($"Response #{LocalRequestId} : {LastResponse.StatusCode}", StringContent);

  //    return JsonContent;

  //  } catch (HttpRequestException ex) {
  //    Logger.LogErrorBox($"Unable to read string from client request #{LocalRequestId}", ex);
  //    if (ex.Data is not null) {
  //      StringBuilder Data = new();
  //      foreach (KeyValuePair item in ex.Data) {
  //        Data.Append(item.ToString());
  //      }
  //      Logger.LogErrorBox("Data", Data);
  //    }
  //    if (ex.InnerException is not null) {
  //      Logger.LogErrorBox("  Inner exception", ex.InnerException);
  //    }

  //    LastResponse = new HttpResponseMessage(HttpStatusCode.NoContent);

  //    Logger.LogErrorBox($"{(int)LastResponse.StatusCode}", LastResponse.ReasonPhrase ?? "(null)");
  //    return default;

  //  } catch (Exception ex) {
  //    Logger.LogErrorBox($"Unable to read string from client request #{LocalRequestId}", ex);
  //    if (ex.InnerException is not null) {
  //      Logger.LogError($"  Inner exception : {ex.InnerException.Message}");
  //    }

  //    LastResponse = new HttpResponseMessage(HttpStatusCode.RequestTimeout);

  //    Logger.LogErrorBox($"{(int)LastResponse.StatusCode}", LastResponse.ReasonPhrase ?? "(null)");
  //    return default;
  //  }
  //}
  //#endregion --- Get Json --------------------------------------------

  #region --- Get string --------------------------------------------
  public async Task<string?> GetStringAsync(string uriRequest, CancellationToken cancellationToken) {
    int LocalRequestId = ++RequestId;
    try {

      TGetRequestMessage RequestMessage = new TGetRequestMessage(uriRequest);
      Logger.LogDebugExBox($"Request #{LocalRequestId} : {uriRequest}", "No content");

      LastResponse = await _HttpClient.SendAsync(RequestMessage, cancellationToken).ConfigureAwait(false);

      if (!LastResponse.IsSuccessStatusCode) {
        Logger.LogDebugExBox($"Response #{LocalRequestId} : {LastResponse.StatusCode}", await LastResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
        return default;
      }

      string StringContent = await LastResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

      Logger.LogDebugExBox($"Response #{LocalRequestId} : {LastResponse.StatusCode}", StringContent);

      return StringContent;
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

  public async Task<string?> GetStringAsync<T>(string uriRequest, T additionalContent, CancellationToken cancellationToken) {

    if (additionalContent is null) {
      return default;
    }

    int LocalRequestId = ++RequestId;
    try {

      TPostRequestMessage RequestMessage = new TPostRequestMessage(uriRequest);

      switch (additionalContent) {
        //case IJson AdditionalJsonContent: {
        //    RequestMessage.Content = new StringContent(AdditionalJsonContent.ToJson());
        //    RequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        //    break;
        //  }
        case string AdditionalStringContent: {
            RequestMessage.Content = new StringContent(AdditionalStringContent);
            break;
          }
        default: {
            RequestMessage.Content = new StringContent(additionalContent?.ToString() ?? "");
            break;
          }
      }

      Logger.LogDebugExBox($"Request #{LocalRequestId} : {uriRequest} - Content is {additionalContent?.GetType().Name ?? "(null)"}", additionalContent?.ToString() ?? "(null)");

      LastResponse = await _HttpClient.SendAsync(RequestMessage, cancellationToken).ConfigureAwait(false);

      if (!LastResponse.IsSuccessStatusCode) {
        Logger.LogDebugExBox($"Response #{LocalRequestId} : {LastResponse.StatusCode}", await LastResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
        return default;
      }

      string StringContent = await LastResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

      Logger.LogDebugExBox($"Response #{LocalRequestId} : {LastResponse.StatusCode}", StringContent);

      return StringContent;
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
  #endregion --- Get string --------------------------------------------

  #region --- Probe --------------------------------------------
  public async Task<bool> ProbeServerAsync(CancellationToken cancellationToken) {

    int LocalRequestId = ++RequestId;

    try {
      Logger.LogDebug($"Probing server #{LocalRequestId} : {BaseAddress}");

      //TGetRequestMessage Request = new TGetRequestMessage("/probe");
      //Logger.LogDebug($"Request #{LocalRequestId} : {Request}");
      //Logger.LogDebug($"HttpClient : {_HttpClient}");
      //_HttpClient.BaseAddress = new Uri("http://localhost:1234/probe");
      LastResponse = await _HttpClient.GetAsync("probe", cancellationToken).ConfigureAwait(false);

      //Logger.LogDebug($"Response #{LocalRequestId} : {LastResponse.StatusCode} : Probing {BaseAddress}");

      return true; //      LastResponse.IsSuccessStatusCode;

    } catch (Exception ex) {
      Logger.LogErrorBox($"Unable to probe server ({LocalRequestId}) - {this.ToString()}", ex);
      return false;
    }

  }
  #endregion --- Probe --------------------------------------------

  public async Task<Stream> GetStreamAsync(string uriRequest, CancellationToken cancellationToken) {
    int LocalRequestId = ++RequestId;
    try {
      Logger.LogDebug($"Request: {uriRequest}");

      TGetRequestMessage RequestMessage = new TGetRequestMessage(uriRequest);

      LastResponse = await _HttpClient.SendAsync(RequestMessage, cancellationToken).ConfigureAwait(false);

      if (!LastResponse.IsSuccessStatusCode) {
        throw new HttpRequestException($"Error loading {uriRequest} : {LastResponse.StatusCode} {LastResponse.ReasonPhrase}");
      }

      Stream ContentStream = await LastResponse.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

      Logger.LogDebugExBox($"Response : {LastResponse.StatusCode}", $"Stream length is {ContentStream.Length} bytes");

      return ContentStream;

    } catch (Exception ex) {
      Logger.LogError($"Unable to read stream from client : {ex.Message}");
      if (ex.InnerException is not null) {
        Logger.LogError($"  Inner exception : {ex.InnerException.Message}");
      }

      LastResponse = new HttpResponseMessage(HttpStatusCode.RequestTimeout);

      Logger.LogError($"{(int)LastResponse.StatusCode} : {LastResponse.ReasonPhrase}");
      throw;
    }
  }

  public async Task<byte[]?> GetByteArrayAsync(string uriRequest, CancellationToken cancellationToken) {
    int LocalRequestId = ++RequestId;
    try {
      Logger.LogDebugExBox($"Request #{LocalRequestId}", uriRequest);

      TGetRequestMessage RequestMessage = new TGetRequestMessage(uriRequest);

      LastResponse = await _HttpClient.SendAsync(RequestMessage, cancellationToken).ConfigureAwait(false);
      Logger.LogDebugExBox($"Response #{LocalRequestId}", $"{(int)LastResponse.StatusCode} : {LastResponse.ReasonPhrase}");

      if (!LastResponse.IsSuccessStatusCode) {
        throw new HttpRequestException($"Error loading {uriRequest} : {LastResponse.StatusCode} {LastResponse.ReasonPhrase}");
      }

      byte[] BytesContent = await LastResponse.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);

      Logger.LogDebugExBox($"Response #{LocalRequestId} content", BytesContent.ToHexString());

      return BytesContent;

    } catch (HttpRequestException ex) {
      Logger.LogErrorBox($"Response #{LocalRequestId} : Unable to read byte[] from client", ex);
      if (ex.InnerException is not null) {
        Logger.LogErrorBox("  Inner exception", ex.InnerException);
      }
      throw;
    } catch (TaskCanceledException ex) {
      Logger.LogErrorBox($"Response #{LocalRequestId} : Unable to read byte[] from client", ex);
      if (ex.InnerException is not null) {
        Logger.LogErrorBox("  Inner exception", ex.InnerException);
      }
      LastResponse = new HttpResponseMessage(HttpStatusCode.RequestTimeout);
      throw;
    } catch (Exception ex) {
      Logger.LogErrorBox($"Response #{LocalRequestId} : Unable to read byte[] from client", ex);
      if (ex.InnerException is not null) {
        Logger.LogErrorBox("  Inner exception", ex.InnerException);
      }
      throw;
    }
  }

}
