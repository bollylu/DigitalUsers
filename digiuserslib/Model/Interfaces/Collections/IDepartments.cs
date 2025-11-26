namespace digiuserslib.Model;

public interface IDepartments : IList<IDepartment> {

  IDepartment? this[string keyId] { get; }

}
