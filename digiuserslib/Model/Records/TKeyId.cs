using System.Diagnostics.CodeAnalysis;

namespace digiuserslib.Model;

public class TKeyId : IKeyId  {

  public string Value { get; set; } = string.Empty;

  [JsonIgnore]
  public ILogger Logger { get; } = new TTraceLogger() { Name = nameof(TKeyId) };

  [JsonIgnore]
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
    RetVal.Append($"{nameof(Value)} = {Value.WithQuotes()}");
    return RetVal.ToString();
  }

  public bool Equals(IKeyId? x, IKeyId? y) {
    if (x is null && y is null) {
      return true;
    }
    if (x is null || y is null) {
      return false;
    }
    Logger.LogDebug($"Comparing TKeyId: {x.Value.WithQuotes()} with {y.Value.WithQuotes()}");
    return string.Equals(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
  }

  public int GetHashCode([DisallowNull] IKeyId obj) {
    return obj.Value?.GetHashCode() ?? 0;
  }

}
