namespace digiuserslib;

public interface IDepartment : IInvalid {
  string Id { get; }
  string Name { get; }
  string Description { get; }
  string DependsOn { get; }
}
