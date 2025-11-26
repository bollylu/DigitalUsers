using System.Diagnostics;

namespace digiuserslib;

public class TTraceLogger : ALogger {

  protected override void _Initialize() {
    if (!_IsInitialized) {
      base.Output = delegate (string x) {
        Trace.WriteLine(x);
      };
      _IsInitialized = true;
    }
  }
}
