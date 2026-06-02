namespace digiusersmodelslib;

public interface IId<T> : IInvalid {
  T Value { get; }
}

