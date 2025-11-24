
using System.Runtime.CompilerServices;

namespace digiuserslib.Interfaces {
  
  public interface IPersons : IList<IPerson> {

        IPerson? this[string keyId] { get; }
    
  }

}
