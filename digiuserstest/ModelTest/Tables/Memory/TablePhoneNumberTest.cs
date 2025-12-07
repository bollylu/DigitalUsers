using digiuserslib.Model;

namespace digiuserstest.ModelTest;
public class TablePhoneNumberTest {

  [SetUp]
  public void Setup() {

  }

  [Test]
  public void TablePhoneNumber_IsOk() {
    Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory Numbers = new();
    Assert.That(Numbers, Is.Not.Null);
    Dump(Numbers, 3);
    Ok();
  }

  [Test]
  public void TablePhoneNumber_GetAll() {
    Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    Message("Get all phone numbers");
    IEnumerable<IPhoneNumber> Numbers = TableNumbers.GetAll();
    Message($"Check that there are phone numbers ({Numbers.Count()})");
    Assert.That(Numbers.Any(), Is.True);
    Dump(Numbers, 3);
    Ok();
  }

  [Test]
  public void TablePhoneNumber_Get_Ok() {
    Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    IKeyId NumberId = RPhoneNumber.BollyLucOffice.Id;
    Message($"Get existing phone number {NumberId.Value.WithQuotes()}");
    IPhoneNumber? Number = TableNumbers.Get(NumberId);
    Message("Check that the phone number is not null and has the correct id");
    Assert.That(Number, Is.Not.Null);
    Assert.That(Number.Id, Is.EqualTo(NumberId));
    Dump(Number, 3);
    Ok();
  }

  [Test]
  public void TablePhoneNumber_Get_Bad() {
    Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    IKeyId PhoneId = TKeyId.Empty;
    Message($"Get missing phone number {PhoneId.Value.WithQuotes()}");
    IPhoneNumber? PhoneNumber = TableNumbers.Get(PhoneId);
    Message("Check that the phone number is null");
    Assert.That(PhoneNumber, Is.Null);
    Ok();
  }
}
