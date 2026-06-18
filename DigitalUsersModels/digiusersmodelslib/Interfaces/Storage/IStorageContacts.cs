using System;
using System.Collections.Generic;
using System.Text;

namespace digiusersmodelslib {
  public interface IStorageContacts {

    IEnumerable<IContact> GetContacts();
    IContact? GetContact(TKeyId id);
    IContact? AddContact(IContact contact);
    IContact? UpdateContact(IContact contact);
    IContact? DeleteContact(TKeyId id);

  }

  public interface IStorageContactsJson<T> : IStorageContacts where T : IContact, IJson {
    bool Save(IContacts contacts);
    IContacts Read();
  }
}
