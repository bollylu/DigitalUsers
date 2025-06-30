using digiuserslib;

namespace digiuserstest;

public class PhoneNumberTest {
  [SetUp]
  public void Setup() {
  }

  private readonly IDataSource DataSource = new TDataSourceMemory();

  [Test]
  public void Test1() {
    Assert.Pass();
  }
}
