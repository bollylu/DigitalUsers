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

builder.Services.AddCors(options =>
{
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

app.MapGet("/probe", () => { return "OK"; }).Produces(200);


app.MapGet("/contacts/getall", async () =>
{
  app.Logger.LogInformation($"Request /contact/getall");
  TContacts Contacts = [.. await DataSource.GetContactsAsync().ToListAsync()];
  return Contacts; // Ensure the result is returned
})
.WithName("GetAllContacts");

app.MapGet("/locations/getall", async () =>
{
  app.Logger.LogInformation($"Request /locations/getall");
  TLocations Locations = [.. await DataSource.GetLocationsAsync().ToListAsync()];
  return Locations; // Ensure the result is returned
})
.WithName("GetAllLocations");

app.MapGet("/phones/getall", async () =>
{
  app.Logger.LogInformation($"Request /phones/getall");
  TPhoneNumbers PhoneNumbers = [.. await DataSource.GetPhoneNumbersAsync().ToListAsync()];
  return PhoneNumbers; // Ensure the result is returned
})
.WithName("GetAllPhoneNumbers");

app.MapGet("/departments/getall", async () =>
{
  app.Logger.LogInformation($"Request /departments/getall");
  TDepartments Departments = [.. await DataSource.GetDepartmentsAsync().ToListAsync()];
  return Departments; // Ensure the result is returned
})
.WithName("GetAllDepartments");

app.MapGet("/mailaddresses/getall", async () =>
{
  app.Logger.LogInformation($"Request /mailaddresses/getall");
  TMailAddresses MailAddresses = [.. await DataSource.GetMailAddressesAsync().ToListAsync()];
  return MailAddresses; // Ensure the result is returned
})
.WithName("GetAllMailAddresses");

app.MapGet("/contacts/get/{id}", async (string id) =>
{
  app.Logger.LogInformation($"Request /contacts/get {id.WithQuotes()}");
  return await DataSource.GetContactAsync(new TKeyId(id));
}).WithName("GetContactById");

app.MapGet("/contacts/delete/{id}", async (string id) =>
{
  app.Logger.LogInformation($"Request /contacts/delete {id.WithQuotes()}");
  return await DataSource.DeleteContactAsync(new TKeyId(id));
}).WithName("DeleteContactById");

app.MapPost("/contacts/create", async (RContactBasic contact) =>
{
  app.Logger.LogInformation($"Request /contacts/create {contact.Id.Value.WithQuotes()}");
  return await DataSource.CreateContactAsync(contact);
}).WithName("CreateContact");

app.MapPost("/phonenumbers/create", async (RPhoneNumber phoneNumber) =>
{
  app.Logger.LogInformation($"Request /phonenumbers/create {phoneNumber.Id.Value.WithQuotes()}");
  IPhoneNumber? Result = await DataSource.CreatePhoneNumberAsync(phoneNumber);
  if (Result is null) {
    app.Logger.LogError($"Unable to create phone number {phoneNumber.Id.Value.WithQuotes()}");
    return Results.BadRequest();
  }
  return Results.Ok(Result);
}).WithName("CreatePhoneNumber");

app.Run();


