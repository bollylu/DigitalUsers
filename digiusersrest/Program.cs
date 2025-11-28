using System.Linq; // Add this namespace for LINQ methods like ToListAsync
using System.Runtime.CompilerServices;

using BLTools;

using digiuserslib;
using digiuserslib.Model;

//const string ARG_DATAFILE = "datafile";

ISplitArgs Args = new SplitArgs();

bool IsDebug = Args.IsDefined("debug");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddLogging(logger => logger.AddConsole());

builder.Services.AddCors(options => {
  options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.MapOpenApi();
} else {
  app.UseHttpsRedirection();
}

IDataSourceAsync DataSource;
//if (IsDebug) {
DataSource = new TDataSourceMemory();
//} else {
//DataSource = new TDataSourceFile();
// If datasource is missing, create it as a copy of memory datasource
//if (!await DataSource.Open()) {
//  DataSource = new TDataSourceFile(new TDataSourceMemory(), DataFile);
//  if (!await DataSource.Save()) {
//    app.Logger.LogCritical("Unable to build datafile");
//    Environment.Exit(1);
//  }
//}
//await DataSource.ReadAsync();
//}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Health probe
app.MapGet("/probe", () => { return "OK"; }).Produces(200);

#region --- GetAll ------------------------------------------------------------
app.MapGet("/contacts/getall", async () => {
  app.Logger.LogInformation("Request /contact/getall");
  TContacts Contacts = [.. await DataSource.GetContactsAsync().ToListAsync()];
  return Contacts; // Ensure the result is returned
})
.WithName("GetAllContacts");

app.MapGet("/locations/getall", async () => {
  app.Logger.LogInformation("Request /locations/getall");
  TLocations Locations = [.. await DataSource.GetLocationsAsync().ToListAsync()];
  return Locations; // Ensure the result is returned
})
.WithName("GetAllLocations");

app.MapGet("/phones/getall", async () => {
  app.Logger.LogInformation("Request /phones/getall");
  TPhoneNumbers PhoneNumbers = [.. await DataSource.GetPhoneNumbersAsync().ToListAsync()];
  return PhoneNumbers; // Ensure the result is returned
})
.WithName("GetAllPhoneNumbers");

app.MapGet("/departments/getall", async () => {
  app.Logger.LogInformation("Request /departments/getall");
  TDepartments Departments = [.. await DataSource.GetDepartmentsAsync().ToListAsync()];
  return Departments; // Ensure the result is returned
})
.WithName("GetAllDepartments");

app.MapGet("/mailaddresses/getall", async () => {
  app.Logger.LogInformation("Request /mailaddresses/getall");
  TMailAddresses MailAddresses = [.. await DataSource.GetMailAddressesAsync().ToListAsync()];
  return MailAddresses; // Ensure the result is returned
})
.WithName("GetAllMailAddresses");
#endregion --------------------------------------------------------------------

#region --- GetById -----------------------------------------------------------
app.MapGet("/contacts/get/{id}", async (string id) => {
  app.Logger.LogInformation($"Request /contact/get {id.WithQuotes()}");
  return await DataSource.GetContactAsync(id);
}).WithName("GetContactById");

app.MapGet("/departments/get/{id}", async (string id) => {
  app.Logger.LogInformation($"Request /departments/get {id.WithQuotes()}");
  return await DataSource.GetDepartmentAsync(id);
}).WithName("GetDepartmentById");

app.MapGet("/locations/get/{id}", async (string id) => {
  app.Logger.LogInformation($"Request /locations/get {id.WithQuotes()}");
  return await DataSource.GetLocationAsync(id);
}).WithName("GetLocationById");

app.MapGet("/phonenumbers/get/{id}", async (string id) => {
  app.Logger.LogInformation($"Request /phonenumbers/get {id.WithQuotes()}");
  return await DataSource.GetPhoneNumberAsync(id);
}).WithName("GetPhoneNumberById");

app.MapGet("/mailaddresses/get/{id}", async (string id) => {
  app.Logger.LogInformation($"Request /mailaddresses/get {id.WithQuotes()}");
  return await DataSource.GetMailAddressAsync(id);
}).WithName("GetMailAddressById");
#endregion --------------------------------------------------------------------

app.Run();

