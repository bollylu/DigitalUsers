
using System.Runtime.CompilerServices;

namespace digiuserslib.Model {
  
  public interface IContacts : IList<IContact> {

        IContact? this[string keyId] { get; }
    
  }

}
