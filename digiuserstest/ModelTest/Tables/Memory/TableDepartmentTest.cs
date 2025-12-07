using digiuserslib.Model;

namespace digiuserstest.ModelTest;
public class TableDepartmentTest {

  [SetUp]
  public void Setup() {

  }

  [Test]
  public void TableDepartmentMemory_IsOk() {
    Message("Create an table of departments");
    TTableDepartmentsMemory Departments = new();
    Assert.That(Departments, Is.Not.Null);
    Dump(Departments, 3);
    Ok();
  }

  [Test]
  public void TableDepartmentMemory_GetAll() {
    Message("Create an table of departments");
    TTableDepartmentsMemory TableDepartments = new();
    Message("Get all departments");
    IEnumerable<IDepartment> Departments = TableDepartments.GetAll();
    Assert.That(Departments.Any(), Is.True);
    Dump(Departments, 3);
    Ok();
  }

  [Test]
  public void TableDepartmentMemory_Get_Ok() {
    Message("Create an table of departments");
    TTableDepartmentsMemory TableDepartments = new();
    IKeyId DepartmentId = RDepartment.GestionInformatique.Id;
    Message($"Get existing department {DepartmentId.Value.WithQuotes()}");
    IDepartment? Department = TableDepartments.Get(DepartmentId);
    Assert.That(Department, Is.Not.Null);
    Assert.That(Department.Id, Is.EqualTo(DepartmentId));
    Dump(Department, 3);
    Ok();
  }

  [Test]
  public void TableDepartmentMemory_Get_Bad() {
    Message("Create an table of departments");
    TTableDepartmentsMemory TableDepartments = new();
    IKeyId DepartmentId = new TKeyId("xxxxxxx");
    Message($"Get missing department {DepartmentId}");
    IDepartment? Department = TableDepartments.Get(DepartmentId);
    Assert.That(Department, Is.Null);
    Ok();
  }
}
