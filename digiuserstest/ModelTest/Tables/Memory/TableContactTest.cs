using digiuserslib.Model;

using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Tracing.Interfaces;

namespace digiuserstest.ModelTest;

public class TableContactTest {

  [SetUp]
  public void Setup() {

  }

  [Test]
  public void TableContactMemory_IsOk() {
    Message("Create an table of contacts");
    TTableContactsMemory TableContact = new();
    Assert.That(TableContact, Is.Not.Null);
    Dump(TableContact, 3);
    Ok();
  }

  [Test]
  public void TableContactMemory_GetAll() {
    Message("Create an table of contacts");
    TTableContactsMemory TableContact = new();
    Message("Get all contacts");
    IEnumerable<IContact> Contacts = TableContact.GetAll();
    Assert.That(Contacts.Any(), Is.True);
    Dump(Contacts, 3);
    Ok();
  }

  [Test]
  public void TableContactMemory_Get_Ok() {
    Message("Create an table of contacts");
    TTableContactsMemory TableContact = new();
    IKeyId ContactId = RContact.DupontJean.Id;
    Message($"Get existing contact {ContactId.Value.WithQuotes()}");
    IContact? Agent = TableContact.Get(ContactId);
    Assert.That(Agent, Is.Not.Null);
    Assert.That(Agent.Id, Is.EqualTo(ContactId));
    Dump(Agent, 3);
    Ok();
  }

  [Test]
  public void TableContactMemory_Get_Bad() {
    Message("Create an table of contacts");
    TTableContactsMemory TableContact = new();
    string ContactId = "xxxxxxx";
    Message($"Get missing agent {ContactId.WithQuotes()}");
    IContact? Contact = TableContact.Get(ContactId);
    Assert.That(Contact, Is.Null);
    Ok();
  }
}
