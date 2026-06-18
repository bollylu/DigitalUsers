namespace digiusersmodelslib;

public interface ICollection<T> : IList<T> where T : IRecord {
  T? this[string keyId] { get; }
}
