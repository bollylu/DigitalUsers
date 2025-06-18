using digiuserslib;

using digiusersweb;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddLogging();



ILogger Logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

TDataSourceWebWithCache DataSource = new TDataSourceWebWithCache(new Uri("http://localhost:1234"));
if (!await DataSource.Open()) {
  Logger.LogCritical("Missing datasource");
  return;
}

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region --- Bus --------------------------------------------
builder.Services.AddSingleton<IBusService<string>, TBusService<string>>();
#endregion --- Bus --------------------------------------------

await builder.Build().RunAsync();
