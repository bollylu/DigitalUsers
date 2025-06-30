namespace digiuserslib;

public interface IDepartment : IRecord, IInvalid {
  string Name { get; }
  string Description { get; }
  string DependsOn { get; }
}
