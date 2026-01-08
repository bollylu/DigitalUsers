using digiuserslib.Model;
using ILogger = BLTools.Core.Logging.ILogger;

namespace digiuserstest.ModelTest;

public class DepartmentTest {

  private ILogger Logger;

  [OneTimeSetUp]
  public void Setup() {
    Logger = new TConsoleLogger<DepartmentTest>();
    Logger.Message("----- Department tests -----");
  }

  [OneTimeTearDown]
  public void Cleanup() {
    Logger.Dispose();
  }

  [Test]
  public void Department_IsInvalid() {
    Logger.Message("Create an invalid department");
    IDepartment Department = RDepartment.Empty;
    Assert.That(Department.IsInvalid, Is.True);
    Logger.Dump(Department, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void Department_IsValid() {
    Logger.Message("Create a valid department");
    IDepartment Department = RDepartment.Direction;
    Assert.That(Department.IsValid, Is.True);
    Assert.That(Department.Id.Value, Is.EqualTo("direction"));
    Assert.That(Department.Name, Is.EqualTo("Direction générale"));
    Assert.That(Department.HeadOfDepartment.First(), Is.EqualTo(RContactBasic.AdamBruno));
    Logger.Dump(Department, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  
}
