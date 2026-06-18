namespace digiusersmodelslib;

public class TKeyId : ILoggable, IId<string>, IEqualityComparer<TKeyId>, IEquatable<TKeyId> {

  public string Value { get; set; } = string.Empty;

  [JsonIgnore]
  public ILogger Logger { get; } = new TTraceLogger() { Name = nameof(TKeyId) };

  [JsonIgnore]
  public bool IsInvalid => Value.Trim().IsEmpty();

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TKeyId() { }
  public TKeyId(string id) { Value = id; }
  public TKeyId(TKeyId id) { Value = id.Value; }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

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

  public override bool Equals(object? obj) {
    return base.Equals(obj);
  }

  public override int GetHashCode() {
    return base.GetHashCode();
  }

  public bool Equals(TKeyId? x, TKeyId? y) {
    if (x is null && y is null) {
      return true;
    }
    if (x is null || y is null) {
      return false;
    }
    bool isEqual = string.Equals(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
    Logger.LogDebug($"Comparing TKeyId: {x.Value.WithQuotes()} with {y.Value.WithQuotes()} : {isEqual}");
    return isEqual;
  }

  public int GetHashCode(TKeyId obj) {
    return obj?.Value?.GetHashCode() ?? 0;
  }

  // Comparaison avec un autre TKeyId en spécifiant le mode
  public bool Equals(TKeyId? other, StringComparison comparisonType) {
    if (other is null) {
      return false;
    }

    if (ReferenceEquals(this, other)) {
      return true;
    }

    bool isEqual = string.Equals(Value, other.Value, comparisonType);
    Logger.LogDebug($"Comparing TKeyId: {Value.WithQuotes()} with {other.Value.WithQuotes()} ({comparisonType}) : {isEqual}");
    return isEqual;
  }

  // Comparaison avec une string en spécifiant le mode
  public bool Equals(string? other, StringComparison comparisonType) {
    return string.Equals(Value, other, comparisonType);
  }

  // Mettez à jour votre Equals(TKeyId?) par défaut pour appeler la nouvelle méthode
  public bool Equals(TKeyId? other) {
    // Par défaut, on reste sur de l'insensible à la casse (OrdinalIgnoreCase)
    return Equals(other, StringComparison.OrdinalIgnoreCase);
  }
}
