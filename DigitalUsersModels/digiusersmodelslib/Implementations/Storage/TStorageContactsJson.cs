using System;
using System.Collections.Generic;
using System.Text;

namespace digiusersmodelslib {
  public class TStorageContactsJson : IStorageContactsJson<TContact> {

    private readonly List<IContact> _contacts = [];
    public string Filename { get; init; } = string.Empty;

    public TStorageContactsJson(string filename) {
      Filename = filename;
    }

    public IContact? AddContact(IContact contact) {
      _contacts.Add(contact);
      return contact;
    }

    public IContact? DeleteContact(TKeyId id) {
      int Index = _contacts.FindIndex(c => c.Id.Equals(id));
      if (Index != -1) {
        IContact contact = _contacts[Index];
        _contacts.RemoveAt(Index);
        return contact;
      }
      return null;
    }

    public IContact? GetContact(TKeyId id) {
      return _contacts.FirstOrDefault(c => c.Id.Equals(id));
    }

    public IEnumerable<IContact> GetContacts() {
      return _contacts;
    }

    public IContact? UpdateContact(IContact contact) {
      int Index = _contacts.FindIndex(c => c.Id.Equals(contact.Id));
      if (Index != -1) {
        _contacts[Index] = contact;
        return contact;
      }
      return null;
    }

    public IContacts Read() {
      if (string.IsNullOrEmpty(Filename)) {
        return new TContacts();
      }
      string FileContent = File.ReadAllText(Filename);
      IContacts contacts = JsonSerializer.Deserialize<TContacts>(FileContent) ?? new TContacts();
      return contacts;
    }

    public bool Save(IContacts contacts) {
      if (string.IsNullOrEmpty(Filename)) {
        return false;
      }
      using FileStream fs = new(Filename, FileMode.Create);
      using StreamWriter sw = new(fs);
      foreach (IJson contact in contacts) {
        sw.WriteLine(contact.ToJson());
      }
      return true;
    }
  }
}
