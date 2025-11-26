namespace digiuserslib.Model;

public interface IDependency {
  string Id { get; }
  string DependsOn { get; }
}
