namespace digiuserslib.Model;

public interface IDepartment : IDepartmentBasic {
  IList<IKeyId> HeadsOfDepartment { get; }
}
