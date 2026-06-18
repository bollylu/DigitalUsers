namespace digiusersmodelslib {
  public interface IJson {
    string ToJson();
  }

  public interface IJson<T> : IJson {
    T FromJson(string json);
  }
}
