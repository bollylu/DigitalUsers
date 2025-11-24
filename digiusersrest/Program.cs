using System.Linq; // Add this namespace for LINQ methods like ToListAsync
using System.Runtime.CompilerServices;

using BLTools;

using digiuserslib;

const string ARG_DATAFILE = "datafile";

ISplitArgs Args = new SplitArgs();

bool IsDebug = Args.IsDefined("debug");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddLogging(logger => logger.AddConsole());

builder.Services.AddCors(options =>
{
  options.AddPolicy("PolicyName", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("PolicyName");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.MapOpenApi();
} else {
  app.UseHttpsRedirection();
}

IDataSource DataSource;
if (IsDebug) {
  DataSource = new TDataSourceMemory();
} else {
  DataSource = new TDataSourceFile();
  // If datasource is missing, create it as a copy of memory datasource
  //if (!await DataSource.Open()) {
  //  DataSource = new TDataSourceFile(new TDataSourceMemory(), DataFile);
  //  if (!await DataSource.Save()) {
  //    app.Logger.LogCritical("Unable to build datafile");
  //    Environment.Exit(1);
  //  }
  //}
  await DataSource.ReadAsync();
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

app.MapGet("/probe", () => { return "OK"; }).Produces(200);


//app.MapGet("/getall", async () =>
//{
//  app.Logger.LogInformation($"Request /getall");
//  await DataSource.Open();
//  var locations = await DataSource.GetLocationsAsync(); // Fix: Use ToListAsync to materialize the async enumerable
//  return locations; // Ensure the result is returned
//})
//.WithName("GetAll");

//app.MapGet("/get/{id}", (string id) =>
//{
//  app.Logger.LogInformation($"Request /get {id}");
//  return DataSource.GetPerson(id);
//}).WithName("Get");

app.Run();


