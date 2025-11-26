namespace digiuserslib.Model;

public interface IDepartment : IRecord, IInvalid {
  string Name { get; }
  string Description { get; }
  TKeyId HeadOfDepartment { get; }
}
