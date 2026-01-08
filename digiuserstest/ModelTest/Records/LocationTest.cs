using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using digiuserslib.Model;

using ILogger = BLTools.Core.Logging.ILogger;

namespace digiuserstest.ModelTest;
public class LocationTest {

  private ILogger Logger;

  [OneTimeSetUp]
  public void Setup() {
    Logger = new TConsoleLogger<LocationTest>();
    Logger.Message("----- Location tests -----");
  }

  [OneTimeTearDown]
  public void Cleanup() {
    Logger.Dispose();
  }

  [Test]
  public void Location_IsInvalid() {
    Logger.Message("Create an invalid location");
    ILocation Location = new RLocation();
    Assert.That(Location.IsInvalid, Is.True);
    Logger.Dump(Location, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void Location_IsValid() {
    Logger.Message("Create a valid location");
    ILocation Location = RLocation.CiteAdministrative;
    Assert.That(Location.IsValid, Is.True);
    Logger.Dump(Location, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }
}
