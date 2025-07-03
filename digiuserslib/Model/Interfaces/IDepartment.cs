namespace digiuserslib;

public interface IDepartment : IRecord, IInvalid, IHierarchy {
  string Name { get; }
  string Description { get; }
  TKeyId HeadOfDepartment { get; }
  IHierarchy? DependsOn { get; }
}
