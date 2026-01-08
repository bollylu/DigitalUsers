using digiuserslib.Model;

using ILogger = BLTools.Core.Logging.ILogger;

namespace digiuserstest.ModelTest;

public class TablePhoneNumberTest {

  private ILogger Logger;

  [OneTimeSetUp]
  public void Setup() {
    Logger = new TConsoleLogger<TablePhoneNumberTest>();
    Logger.Message($"----- {nameof(TablePhoneNumberTest)} tests -----");
  }

  [OneTimeTearDown]
  public void Cleanup() {
    Logger.Dispose();
  }

  [Test]
  public void TablePhoneNumber_IsOk() {
    Logger.Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory Numbers = new();
    Assert.That(Numbers, Is.Not.Null);
    Logger.Dump(Numbers, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void TablePhoneNumber_GetAll() {
    Logger.Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    Logger.Message("Get all phone numbers");
    IEnumerable<IPhoneNumber> Numbers = TableNumbers.GetAll();
    Logger.Message($"Check that there are phone numbers ({Numbers.Count()})");
    Assert.That(Numbers.Any(), Is.True);
    Logger.Dump(Numbers, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void TablePhoneNumber_Get_Ok() {
    Logger.Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    IKeyId NumberId = RPhoneNumber.BollyLucOffice.Id;
    Logger.Message($"Get existing phone number {NumberId.Value.WithQuotes()}");
    IPhoneNumber? Number = TableNumbers.Get(NumberId);
    Logger.Message("Check that the phone number is not null and has the correct id");
    Assert.That(Number, Is.Not.Null);
    Assert.That(Number.Id, Is.EqualTo(NumberId));
    Logger.Dump(Number, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void TablePhoneNumber_Get_Bad() {
    Logger.Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    IKeyId PhoneId = TKeyId.Empty;
    Logger.Message($"Get missing phone number {PhoneId.Value.WithQuotes()}");
    IPhoneNumber? PhoneNumber = TableNumbers.Get(PhoneId);
    Logger.Message("Check that the phone number is null");
    Assert.That(PhoneNumber, Is.Null);
    Logger.Ok();
  }
}
