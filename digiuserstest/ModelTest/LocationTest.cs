using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using digiuserslib;

namespace digiuserstest.ModelTest;
public class LocationTest {

  [SetUp]
  public void Setup() {
    DataSource.Open();
    DataSource.Read();
  }

  private readonly IDataSource DataSource = new TDataSourceMemory();

  [Test]
  public void TDataSourceMemory_GetLocations() {
    Message("Get the locations");
    IEnumerable<ILocation> Locations = DataSource.GetLocationsAsync().ToBlockingEnumerable();
    Assert.That(Locations.Any(), Is.True);
    Dump(Locations, 3);
    Ok();
  }

  [Test]
  public async Task TDataSourceMemory_GetLocationsById() {
    Message("Get the location by Id");
    ILocation? Location = await DataSource.GetLocationAsync(RLocation.CiteAdministrative.Id);
    Assert.That(Location, Is.Not.Null);
    Dump(Location, 3);
    Ok();
  }
}
