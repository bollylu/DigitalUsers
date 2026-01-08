using digiuserslib.Model;

using ILogger = BLTools.Core.Logging.ILogger;

namespace digiuserstest.ModelTest;
public class TableDepartmentTest {

  private ILogger Logger;

  [OneTimeSetUp]
  public void Setup() {
    Logger = new TConsoleLogger<TableDepartmentTest>();
    Logger.Message($"----- {nameof(TableDepartmentTest)} tests -----");
  }

  [OneTimeTearDown]
  public void Cleanup() {
    Logger.Dispose();
  }

  [Test]
  public void TableDepartmentMemory_IsOk() {
    Logger.Message("Create an table of departments");
    TTableDepartmentsMemory Departments = new();
    Assert.That(Departments, Is.Not.Null);
    Logger.Dump(Departments, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void TableDepartmentMemory_GetAll() {
    Logger.Message("Create an table of departments");
    TTableDepartmentsMemory TableDepartments = new();
    Logger.Message("Get all departments");
    IEnumerable<IDepartment> Departments = TableDepartments.GetAll();
    Assert.That(Departments.Any(), Is.True);
    Logger.Dump(Departments, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void TableDepartmentMemory_Get_Ok() {
    Logger.Message("Create an table of departments");
    TTableDepartmentsMemory TableDepartments = new();
    IKeyId DepartmentId = RDepartment.GestionInformatique.Id;
    Logger.Message($"Get existing department {DepartmentId.Value.WithQuotes()}");
    IDepartment? Department = TableDepartments.Get(DepartmentId);
    Assert.That(Department, Is.Not.Null);
    Assert.That(Department.Id, Is.EqualTo(DepartmentId));
    Logger.Dump(Department, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void TableDepartmentMemory_Get_Bad() {
    Logger.Message("Create an table of departments");
    TTableDepartmentsMemory TableDepartments = new();
    IKeyId DepartmentId = new TKeyId("xxxxxxx");
    Logger.Message($"Get missing department {DepartmentId}");
    IDepartment? Department = TableDepartments.Get(DepartmentId);
    Assert.That(Department, Is.Null);
    Logger.Ok();
  }
}
