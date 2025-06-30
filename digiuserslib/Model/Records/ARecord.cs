using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digiuserslib;
public abstract record ARecord : IRecord, IInvalid {
  public TKeyId Id { get; set; } = string.Empty;

  public virtual bool IsInvalid => Id.IsInvalid;
}
