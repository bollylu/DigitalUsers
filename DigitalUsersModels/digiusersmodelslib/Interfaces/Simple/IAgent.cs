using System.ComponentModel.Design.Serialization;

namespace digiusersmodelslib;

public interface IAgent : IContact {

  IDepartments Departments { get; }

  IManager Manager { get; }

}
