using digiusersweb;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddLogging();



ILogger Logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

List<string> ApiServerAddresses = [
  "http://localhost:1234","https://localhost:1235"];

TApiServer? ApiServer = null;
foreach (string ApiServerAddressItem in ApiServerAddresses) {
  TApiServer TestApiServer = new TApiServer(ApiServerAddressItem);
  using (CancellationTokenSource Timeout = new CancellationTokenSource(5000)) {
    if (await TestApiServer.ProbeServerAsync(Timeout.Token)) {
      ApiServer = TestApiServer;
      break;
    } else {
      ApiServer = null;
    }
  }
}
if (ApiServer is null) {
  Logger.LogCritical("Missing api server");
  return;
} else {
  Logger.LogInformation($"ApiServer={ApiServer}");
}
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region --- Bus --------------------------------------------
builder.Services.AddSingleton<IBusService<string>, TBusService<string>>();
#endregion --- Bus --------------------------------------------

await builder.Build().RunAsync();
