using digiuserslib;
using static BLTools.Diagnostic.TraceInfo;

namespace digiuserstest {
  public class Tests {
    [SetUp]
    public void Setup() {
    }

    [Test]
    public void ConvertPeopleToMermaid_GetDepartments() {
      Message("Get the departments");
      TPeople People = new();
      IDataSource MemDatasource = new TDataSourceMemory();
      People.AddRange(MemDatasource.GetPeople());
      Assert.That(People.GetDepartments().Any(), Is.True);
      Ok();
    }

    [Test]
    public void ConvertPeopleToMermaid_GetHeadOfDepartmentInfo() {
      const string DEPARTMENT = "Gestion informatique";
      Message("Get the head of department");
      TPeople People = new();
      IDataSource MemDatasource = new TDataSourceMemory();
      People.AddRange(MemDatasource.GetPeople());

      IPerson? HeadOfIT = People.SingleOrDefault(x => x.Id == "bollylu");
      if (HeadOfIT is null) {
        Assert.Fail("Missing head of IT");
        throw new Exception();
      }
      Assert.That(People.GetHeadOfDepartment(DEPARTMENT)?.Id, Is.Not.Null);
      Assert.That(People.GetHeadOfDepartment(DEPARTMENT)?.Id, Is.EqualTo(HeadOfIT.Id));
      Ok();
    }

    [Test]
    public void ConvertPeopleToMermaid_BuildUser() {
      const string DEPARTMENT = "Gestion informatique";
      Message("Get the head of department");
      TPeople People = new();
      IDataSource MemDatasource = new TDataSourceMemory();
      People.AddRange(MemDatasource.GetPeople());

      IPerson? HeadOfIT = People.SingleOrDefault(x => x.Id == "bollylu");
      Assert.That(HeadOfIT, Is.Not.Null);
      Message(HeadOfIT.Name.FullName);
      string Mermaid = People.BuildUser(HeadOfIT);
      Assert.That(Mermaid, Is.Not.Null);
      Message(Mermaid);
      Ok();
    }
  }
}
