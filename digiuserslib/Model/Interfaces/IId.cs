namespace digiuserslib;

public interface IId<T> : IInvalid {
  T Value { get; }
}

