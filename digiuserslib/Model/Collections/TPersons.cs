using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLTools;

using digiuserslib.Interfaces;

namespace digiuserslib {

  public class TPersons : List<IPerson>, IPersons {
    public IPerson? this[string keyId] => this.FirstOrDefault(p => p.Id.Value.Equals(keyId, StringComparison.OrdinalIgnoreCase));
  }

}
