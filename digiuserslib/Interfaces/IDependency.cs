namespace digiuserslib {
  public interface IDependency {
    string Id { get; }
    string DependsOn { get; }
  }
}
