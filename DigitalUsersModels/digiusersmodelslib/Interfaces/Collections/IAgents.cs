
namespace digiusersmodelslib;

public interface IAgents {

  IAgent? this[string keyId] { get; }

  void AddAgent(IAgent agent);
  void RemoveAgent(IAgent agent);
  void RemoveAgent(string keyId);
  void Clear();
  void UpdateAgent(IAgent agent);
  IEnumerable<IAgent> GetAll();
  IEnumerable<IAgent> GetByDepartment(string departmentId);
  IEnumerable<IAgent> GetByManager(string managerId);
  IEnumerable<IAgent> GetFiltered(Predicate<IAgent> filter);

}


