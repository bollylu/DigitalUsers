using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digiuserslib;
public class TTableLocationsMemory : ATableMemory<ILocation> {

  public override string Name { get; protected set; } = nameof(TTableLocationsMemory);
  public override string Description { get; protected set; } = "All locations";

  public TTableLocationsMemory() : base() { }

  protected override void _Initialize() {
    _Records.Add(RLocation.CiteAdministrative);
    _Records.Add(RLocation.HotelDeVille);
  }
}
