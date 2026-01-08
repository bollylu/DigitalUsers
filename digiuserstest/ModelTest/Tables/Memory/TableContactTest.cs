using digiuserslib.Model;

using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Tracing.Interfaces;

using ILogger = BLTools.Core.Logging.ILogger;

namespace digiuserstest.ModelTest;

public class TableContactTest {

  private ILogger Logger;

  [OneTimeSetUp]
  public void Setup() {
    Logger = new TConsoleLogger<LocationTest>();
    Logger.Message("----- Location tests -----");
  }

  [OneTimeTearDown]
  public void Cleanup() {
    Logger.Dispose();
  }

  [Test]
  public void TableContactMemory_IsOk() {
    Logger.Message("Create an table of contacts");
    TTableContactsMemory TableContact = new();
    Assert.That(TableContact, Is.Not.Null);
    Logger.Dump(TableContact, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void TableContactMemory_GetAll() {
    Logger.Message("Create an table of contacts");
    TTableContactsMemory TableContact = new();
    Logger.Message("Get all contacts");
    IEnumerable<IContact> Contacts = TableContact.GetAll();
    Assert.That(Contacts.Any(), Is.True);
    Logger.Dump(Contacts, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public void TableContactMemory_Get_Ok() {
    Logger.Message("Create an table of contacts");
    TTableContactsMemory TableContact = new();
    IKeyId ContactId = RContact.DupontJean.Id;
    Logger.Message($"Get existing contact {ContactId.Value.WithQuotes()}");
    IContact? Agent = TableContact.Get(ContactId);
    Assert.That(Agent, Is.Not.Null);
    Assert.That(Agent.Id, Is.EqualTo(ContactId));
    Logger.Dump(Agent, new SObjectDumpOptions() { MaxDepth = 3});
    Logger.Ok();
  }

  [Test]
  public void TableContactMemory_Get_Bad() {
    Logger.Message("Create an table of contacts");
    TTableContactsMemory TableContact = new();
    string ContactId = "xxxxxxx";
    Logger.Message($"Get missing agent {ContactId.WithQuotes()}");
    IContact? Contact = TableContact.Get(ContactId);
    Assert.That(Contact, Is.Null);
    Logger.Ok();
  }
}
