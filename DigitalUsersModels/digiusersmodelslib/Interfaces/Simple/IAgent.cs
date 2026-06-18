using System.ComponentModel.Design.Serialization;

namespace digiusersmodelslib;

public interface IAgent : IContact {

  IDepartments DepartmentsMemberOf { get; }

  IManager Manager { get; }

}
