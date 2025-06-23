using digiuserslib;

namespace digiuserstest {
  public class Tests {
    [SetUp]
    public void Setup() {
    }

    [Test]
    public void MemDataSource_GetDepartments() {
      Message("Get the departments");
      IDataSource MemDataSource = new TDataSourceMemory();
      Dump(MemDataSource.GetDepartments());
      Assert.That(MemDataSource.GetDepartments().Any(), Is.True);
      Ok();
    }

    [Test]
    public void MemDataSource_GetHeadOfDepartmentInfo() {
      const string DEPARTMENT = "informatique";
      Message("Get the head of department");
      IDataSource MemDataSource = new TDataSourceMemory();
      IPerson? HeadOfIT = MemDataSource.GetHeadOfDepartment(DEPARTMENT);
      Assert.That(MemDataSource.GetHeadOfDepartment(DEPARTMENT)?.Id, Is.Not.Null);
      Dump(HeadOfIT, 2);
      Ok();
    }

    [Test]
    public void MemDataSource_BuildUser() {
      const string DEPARTMENT = "informatique";
      Message("Get the head of department");
      IDataSource MemDataSource = new TDataSourceMemory();

      TMermaidConverter MermaidConverter = new(MemDataSource);
      string Mermaid = MermaidConverter.BuildUser(MemDataSource.GetHeadOfDepartment(DEPARTMENT)?.Id ?? "");
      Assert.That(Mermaid, Is.Not.Null);
      Dump(Mermaid);
      Ok();
    }

    [Test]
    public void ConvertPeopleToMermaid_BuildDepartment() {
      const string DEPARTMENT = "informatique";
      Message("Get the head of department");
      IDataSource MemDataSource = new TDataSourceMemory();
      TMermaidConverter MermaidConverter = new(MemDataSource);

      string Mermaid = MermaidConverter.BuildDepartment(DEPARTMENT);
      Assert.That(Mermaid, Is.Not.Null);
      Dump(Mermaid);
      Ok();
    }

    [Test]
    public void ConvertPeopleToMermaid_BuildSubDepartments() {
      const string DEPARTMENT = "informatique";
      Message("Get the subdepartments");
      IDataSource MemDataSource = new TDataSourceMemory();
      TMermaidConverter MermaidConverter = new(MemDataSource);

      string Mermaid = MermaidConverter.BuildSubDepartments(DEPARTMENT);
      Assert.That(Mermaid, Is.Not.Null);
      Dump(Mermaid);
      Ok();
    }

    [Test]
    public void ConvertPeopleToMermaid_BuildOrganigram() {
      Message("Builds the organigram");
      IDataSource MemDataSource = new TDataSourceMemory();
      TMermaidConverter MermaidConverter = new(MemDataSource);

      string Mermaid = MermaidConverter.BuildOrganigram();
      Assert.That(Mermaid, Is.Not.Null);
      Console.WriteLine(Mermaid);
      Dump(Mermaid);

      Ok();
    }
  }
}
