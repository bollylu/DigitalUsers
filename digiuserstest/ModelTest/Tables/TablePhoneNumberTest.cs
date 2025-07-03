using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using digiuserslib;

namespace digiuserstest.ModelTest;
public class TablePhoneNumberTest {

  [SetUp]
  public void Setup() {

  }

  [Test]
  public void TableDepartmentMemory_IsOk() {
    Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory Numbers = new();
    Assert.That(Numbers, Is.Not.Null);
    Dump(Numbers, 3);
    Ok();
  }

  [Test]
  public void TableDepartmentMemory_GetAll() {
    Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    Message("Get all phone numbers");
    IEnumerable<IPhoneNumber> Numbers = TableNumbers.GetAll();
    Assert.That(Numbers.Any(), Is.True);
    Dump(Numbers, 3);
    Ok();
  }

  [Test]
  public void TableDepartmentMemory_Get_Ok() {
    Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    string NumberId = RPhoneNumber.BollyLucOffice.Id;
    Message($"Get existing phone number {NumberId}");
    IPhoneNumber? Number = TableNumbers.Get(NumberId);
    Assert.That(Number, Is.Not.Null);
    Assert.That(Number.Id.Value, Is.EqualTo(NumberId));
    Dump(Number, 3);
    Ok();
  }

  [Test]
  public void TableDepartmentMemory_Get_Bad() {
    Message("Instantiate an table of phone numbers");
    TTablePhoneNumbersMemory TableNumbers = new();
    string PhoneId = "xxxxxxx";
    Message($"Get missing phone number {PhoneId}");
    IPhoneNumber? PhoneNumber = TableNumbers.Get(PhoneId);
    Assert.That(PhoneNumber, Is.Null);
    Ok();
  }
}
