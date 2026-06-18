using System;
using System.Collections.Generic;
using System.Text;

namespace digiusersmodelslib {
  public class TStorageContactsMemory : IStorageContacts {

    private readonly List<IContact> _contacts = [];

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
  }
}
