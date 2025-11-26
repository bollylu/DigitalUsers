using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using digiuserslib;
using digiuserslib.Model;

namespace digiuserstest.ModelTest;
public class DepartmentTest {

  [SetUp]
  public void Setup() {
    
  }

  [Test]
  public void Department_IsInvalid() {
    Message("Create an invalid department");
    IDepartment Department = RDepartment.Empty;
    Assert.That(Department.IsInvalid, Is.True);
    Dump(Department, 3);
    Ok();
  }

  [Test]
  public void Department_IsValid() {
    Message("Create a valid department");
    IDepartment Department = RDepartment.Direction;
    Assert.That(Department.IsValid, Is.True);
    Assert.That(Department.Id.Value, Is.EqualTo("direction"));
    Assert.That(Department.Name, Is.EqualTo("Direction générale"));
    Assert.That(Department.HeadOfDepartment.Value, Is.EqualTo("adambr"));
    Dump(Department, 3);
    Ok();
  }
}
