
namespace digiuserslib.Model {
  public class TTablePersonsMemory : ATableMemory<IPerson> {
    public TTablePersonsMemory() {
      _Initialize();
    }

    private bool _IsInitiallized = false;

    protected override void _Initialize() {
      if (_IsInitiallized) {
        return;
      }
      base._Initialize();
      Add(RAgent.BollyLuc);
      Add(RAgent.AdamBruno);
      Add(RAgent.DupontJean);
      Add(RAgent.LefevreClaire);
      Add(RAgent.MartinSophie);
      _IsInitiallized = true;
    }
  }
}
