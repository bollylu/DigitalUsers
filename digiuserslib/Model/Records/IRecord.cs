using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digiuserslib;
public interface IRecord : IInvalid {
  TKeyId Id { get; }
}
