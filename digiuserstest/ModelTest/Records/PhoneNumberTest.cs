using digiuserslib;

using digiuserstest.ModelTest;

using ILogger = BLTools.Core.Logging.ILogger;


namespace digiuserstest;

public class PhoneNumberTest {
  private ILogger Logger;

  [OneTimeSetUp]
  public void Setup() {
    Logger = new TConsoleLogger<PhoneNumberTest>();
    Logger.Message("----- Phone number tests -----");
  }

  [OneTimeTearDown]
  public void Cleanup() {
    Logger.Dispose();
  }

  [Test]
  public void Test1() {
    Assert.Pass();
  }
}
