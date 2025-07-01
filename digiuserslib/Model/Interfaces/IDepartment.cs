namespace digiuserslib;

public interface IDepartment : IRecord, IInvalid, IHierarchy {
  string Name { get; }
  string Description { get; }
  IPerson? HeadOfDepartment { get; }
  IHierarchy? DependsOn { get; }
}
