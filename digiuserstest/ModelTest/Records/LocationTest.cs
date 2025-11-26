using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using digiuserslib.Model;

namespace digiuserstest.ModelTest;
public class LocationTest {

  [SetUp]
  public void Setup() {
    
  }

  [Test]
  public void Location_IsInvalid() {
    Message("Create an invalid location");
    ILocation Location = new RLocation();
    Assert.That(Location.IsInvalid, Is.True);
    Dump(Location, 3);
    Ok();
  }

  [Test]
  public void Location_IsValid() {
    Message("Create a valid location");
    ILocation Location = RLocation.CiteAdministrative;
    Assert.That(Location.IsValid, Is.True);
    Dump(Location, 3);
    Ok();
  }
}
