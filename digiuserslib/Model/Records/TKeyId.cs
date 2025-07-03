using System.Diagnostics.CodeAnalysis;
using System.Text;

using BLTools;
using BLTools.Diagnostic.Logging;

using digiuserslib.Interfaces;

namespace digiuserslib;
public class TKeyId : ALoggable, IId<string>, IEqualityComparer<TKeyId> {
  public string Value { get; set; } = string.Empty;
  public bool IsInvalid => Value.Trim().IsEmpty();

  public TKeyId() { }
  public TKeyId(string id) { Value = id; }

  // convert from string to TKeyId
  public static implicit operator TKeyId(string id) => new(id);
  // convert from TKeyId to string
  public static implicit operator string(TKeyId id) => id.Value;

  public static TKeyId Empty => new();

  public override string ToString() {
    StringBuilder RetVal = new StringBuilder();
    RetVal.Append(Value.WithQuotes());
    return RetVal.ToString();
  }

  public bool Equals(TKeyId? x, TKeyId? y) {
    if (x is null && y is null) {
      return true;
    }
    if (x is null || y is null) {
      return false;
    }
    Logger.Log($"Comparing TKeyId: {x.Value.WithQuotes()} with {y.Value.WithQuotes()}");
    return string.Equals(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
  }

  public int GetHashCode([DisallowNull] TKeyId obj) {
    return obj.Value?.GetHashCode() ?? 0;
  }

  //public string Dump() {
  //  StringBuilder RetVal = new StringBuilder();
  //  RetVal.Append(Value.WithQuotes());
  //  return RetVal.ToString();
  //}

}
