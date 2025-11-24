using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digiuserslib;
public class TPhoneNumbers : List<IPhoneNumber>, IPhoneNumbers {
  public IPhoneNumber OfficePhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Work) ?? new RPhoneNumber();
  public IPhoneNumber MobilePhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Mobile) ?? new RPhoneNumber();
  public IPhoneNumber SecondaryPhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Home) ?? new RPhoneNumber();
}
