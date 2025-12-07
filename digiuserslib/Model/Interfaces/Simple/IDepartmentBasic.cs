namespace digiuserslib.Model;

public interface IDepartmentBasic : IRecord, IInvalid {
  string Name { get; }
  string Description { get; }
}
