using digiuserslib;
using digiuserslib.Model;

namespace digiuserstest.ModelTest;

public class TableContactFileTest {

  [SetUp]
  public void Setup() {

  }

  [Test]
  public void TableContactFile_IsOk() {
    Message("Create an table of contacts");
    TTableContactsFile TableContact = new();
    Assert.That(TableContact, Is.Not.Null);
    Dump(TableContact, 3);
    Ok();
  }

  [Test]
  public async Task TableContactFile_GetAll() {
    string Filename = $"Contacts_{Random.Shared.Next()}.json";

    try {
      Message("Create an table of contacts in memory");
      TTableContactsMemory TableContactsInMemory = new();

      Message("Create an table of contacts in file");

      TTableContactsFile TableContactsFile = new(Filename);

      Message("Get all contacts from memory");
      IEnumerable<IContact> SourceContacts = TableContactsInMemory.GetAll();
      Dump(SourceContacts, 2);
      Assert.That(SourceContacts.Any(), Is.True);

      Message($"Add {SourceContacts.Count()} contacts to file table");
      foreach (IContact ContactItem in SourceContacts) {
        Message($"Add contact {ContactItem.FullName.WithQuotes()} to file table");
        TableContactsFile.Add(ContactItem);
      }
      Dump(TableContactsFile, 2);

      Assert.That(await TableContactsFile.SaveAsync(), Is.True);
      Assert.That(await TableContactsFile.CloseAsync(), Is.True);
      Assert.That(File.Exists(Filename), Is.True);

      Message("Reload contacts from file");
      TTableContactsFile TableContactsFileReloaded = new(Filename);
      Assert.That(await TableContactsFileReloaded.OpenAsync(), Is.True);
      Assert.That(await TableContactsFileReloaded.ReadAsync(), Is.True);
      IEnumerable<IContact> ReloadedContacts = TableContactsFileReloaded.GetAll();
      Dump(ReloadedContacts, 2);
      Assert.That(ReloadedContacts.Count(), Is.EqualTo(SourceContacts.Count()));

      Ok();
    } catch (Exception ex) {
      Failed(ex.Message);
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
