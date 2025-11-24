using digiuserslib;
using digiuserslib.Model.Tables.Memory;

using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Tracing.Interfaces;

namespace digiuserstest.ModelTest;
public class TablePersonTest {

  [SetUp]
  public void Setup() {

  }

  [Test]
  public void TablePersonMemory_IsOk() {
    Message("Create an table of persons");
    TTablePersonMemory Persons = new();
    Assert.That(Persons, Is.Not.Null);
    Dump(Persons, 3);
    Ok();
  }

  [Test]
  public void TablePersonsMemory_GetAll() {
    Message("Create an table of persons");
    TTablePersonMemory TablePersons = new();
    Message("Get all agents");
    IEnumerable<IPerson> Persons = TablePersons.GetAll();
    Assert.That(Persons.Any(), Is.True);
    Dump(Persons, 3);
    Ok();
  }

  [Test]
  public void TableDepartmentMemory_Get_Ok() {
    Message("Create an table of persons");
    TTablePersonMemory TablePersons = new();
    string AgentId = RAgent.AdamBruno.Id;
    Message($"Get existing department {AgentId}");
    IPerson? Agent = TablePersons.Get(AgentId);
    Assert.That(Agent, Is.Not.Null);
    Assert.That(Agent.Id.Value, Is.EqualTo(AgentId));
    Dump(Agent, 3);
    Ok();
  }

  [Test]
  public void TableDepartmentMemory_Get_Bad() {
    Message("Create an table of persons");
    TTablePersonMemory TablePersons = new();
    string AgentId = "xxxxxxx";
    Message($"Get missing agent {AgentId}");
    IPerson? Agent = TablePersons.Get(AgentId);
    Assert.That(Agent, Is.Null);
    Ok();
  }
}
