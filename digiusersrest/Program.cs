using System.Runtime.CompilerServices;

using BLTools;

using digiuserslib;

const string ARG_DATAFILE = "datafile";

ISplitArgs Args = new SplitArgs();

bool IsDebug = Args.IsDefined("debug");
string DataFile = Args.GetValue(ARG_DATAFILE, TDataSourceFile.DEFAULT_DATAFILE);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
  DataSource = new TDataSourceFile(DataFile);
  // If datasource is missing, create it as a copy of memory datasource
  if (!await DataSource.Open()) {
    DataSource = new TDataSourceFile(new TDataSourceMemory(), DataFile);
    if (!await DataSource.Save()) {
      app.Logger.LogCritical("Unable to build datafile");
      Environment.Exit(1);
    }
  }
  await DataSource.Read();
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

app.MapGet("/probe", () => { return "OK"; }).Produces(200);

app.MapGet("/getall", () =>
{
  return DataSource.GetPeople();
})
.WithName("GetAll");

app.MapGet("/get/{id}", (string id) =>
{
  return DataSource.GetPerson(id);
}).WithName("GetById");

app.Run();


