using digiuserslib;
using digiuserslib.Model;

using NUnit.Framework.Internal;

using ILogger = BLTools.Core.Logging.ILogger;


namespace digiuserstest.ModelTest;

public class TableContactFileTest {

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
  public void TableContactFile_IsOk() {
    Logger.Message("Create an table of contacts");
    TTableContactsFile TableContact = new();
    Assert.That(TableContact, Is.Not.Null);
    Logger.Dump(TableContact, new SObjectDumpOptions() { MaxDepth = 3 });
    Logger.Ok();
  }

  [Test]
  public async Task TableContactFile_GetAll() {
    string Filename = $"Contacts_{Random.Shared.Next()}.json";

    try {
      Logger.Message("Create an table of contacts in memory");
      TTableContactsMemory TableContactsInMemory = new();

      Logger.Message("Create an table of contacts in file");

      TTableContactsFile TableContactsFile = new(Filename);

      Logger.Message("Get all contacts from memory");
      IEnumerable<IContact> SourceContacts = TableContactsInMemory.GetAll();
      Logger.Dump(SourceContacts, new SObjectDumpOptions() { MaxDepth = 2 });
      Assert.That(SourceContacts.Any(), Is.True);

      Logger.Message($"Add {SourceContacts.Count()} contacts to file table");
      foreach (IContact ContactItem in SourceContacts) {
        Logger.Message($"Add contact {ContactItem.FullName.WithQuotes()} to file table");
        TableContactsFile.Add(ContactItem);
      }
      Logger.Dump(TableContactsFile, new SObjectDumpOptions() { MaxDepth = 2 });

      Assert.That(await TableContactsFile.SaveAsync(), Is.True);
      Assert.That(await TableContactsFile.CloseAsync(), Is.True);
      Assert.That(File.Exists(Filename), Is.True);

      Logger.Message("Reload contacts from file");
      TTableContactsFile TableContactsFileReloaded = new(Filename);
      Assert.That(await TableContactsFileReloaded.OpenAsync(), Is.True);
      Assert.That(await TableContactsFileReloaded.ReadAsync(), Is.True);
      IEnumerable<IContact> ReloadedContacts = TableContactsFileReloaded.GetAll();
      Logger.Dump(ReloadedContacts, new SObjectDumpOptions() { MaxDepth = 2 });
      Assert.That(ReloadedContacts.Count(), Is.EqualTo(SourceContacts.Count()));

      Logger.Ok();
    } catch (Exception ex) {
      Logger.Failed(ex.Message);
    } finally {
      if (System.IO.File.Exists(Filename)) {
        System.IO.File.Delete(Filename);
      }
    }
  }

  //[Test]
  //public void TableContactMemory_Get_Ok() {
  //  Message("Create an table of contacts");
  //  TTableContactsMemory TableContact = new();
  //  string ContactId = RContact.DupontJean.Id;
  //  Message($"Get existing contact {ContactId.WithQuotes()}");
  //  IContact? Agent = TableContact.Get(ContactId);
  //  Assert.That(Agent, Is.Not.Null);
  //  Assert.That(Agent.Id.Value, Is.EqualTo(ContactId));
  //  Dump(Agent, 3);
  //  Ok();
  //}

  //[Test]
  //public void TableContactMemory_Get_Bad() {
  //  Message("Create an table of contacts");
  //  TTableContactsMemory TableContact = new();
  //  string ContactId = "xxxxxxx";
  //  Message($"Get missing agent {ContactId.WithQuotes()}");
  //  IContact? Contact = TableContact.Get(ContactId);
  //  Assert.That(Contact, Is.Null);
  //  Ok();
  //}
}
