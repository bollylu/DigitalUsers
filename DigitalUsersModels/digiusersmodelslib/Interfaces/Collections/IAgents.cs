
namespace digiusersmodelslib;

public interface IAgents {

  IAgent? this[string keyId] { get; }

  int Count { get; }
  bool IsEmpty { get; }
  bool Any();

  void AddAgent(IAgent agent);
  void RemoveAgent(IAgent agent);
  void RemoveAgent(TKeyId keyId);
  void Clear();
  void UpdateAgent(IAgent agent);
  IEnumerable<IAgent> GetAll();
  IEnumerable<IAgent> GetByDepartment(TKeyId departmentId);
  IEnumerable<IAgent> GetByManager(TKeyId managerId);
  IEnumerable<IAgent> GetFiltered(Predicate<IAgent> filter);

}


