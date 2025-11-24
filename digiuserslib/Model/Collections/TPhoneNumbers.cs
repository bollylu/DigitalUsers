using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digiuserslib.Model {
    public class TPhoneNumbers : List<IPhoneNumber>, IPhoneNumbers {

        public IPhoneNumber? MobilePhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Mobile);

        public IPhoneNumber? WorkPhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Work);

        public IPhoneNumber? HomePhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Home);

    }
}
