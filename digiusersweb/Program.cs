using digiusersweb;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;

var Logger = new Logger<Program>(new LoggerFactory());
var builder = WebAssemblyHostBuilder.CreateDefault(args);

List<string> ApiServerAdresses = new List<string>() {
  "http://localhost:5678/api/",
  "http://digiusers.seraing.priv/api/",
  "https://digiusers.seraing.priv/api/"
};

TApiServer? ApiServer = null;
foreach (string ApiServerAddressItem in ApiServerAdresses) {
  TApiServer TestApiServer = new TApiServer(ApiServerAddressItem);
  using (CancellationTokenSource Timeout = new CancellationTokenSource(5000)) {
    if (await ApiServer.ProbeServerAsync(Timeout.Token)) {
      ApiServer = TestApiServer;
      break;
    } else {
      ApiServer = null;
    }
  }
}
if (ApiServer is null) {
  Logger.LogFatal("Missing api server");
  return;
} else {
  Logger.Log($"ApiServer={ApiServer}");
}
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region --- Bus --------------------------------------------
builder.Services.AddSingleton<IBusService<string>, TBusService<string>>();
#endregion --- Bus --------------------------------------------


await builder.Build().RunAsync();
