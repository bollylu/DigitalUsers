namespace digiusersmodelslib {

  public class TAgents : IAgents {

    private readonly List<IAgent> _agents = [];

    public IAgent? this[string keyId] => _agents.FirstOrDefault(p => p.Id.Value.Equals(keyId, StringComparison.OrdinalIgnoreCase));

    public void AddAgent(IAgent agent) {
      _agents.Add(agent);
    }

    public void Clear() {
      _agents.Clear();
    }

    public IEnumerable<IAgent> GetAll() {
      return _agents;
    }

    public IEnumerable<IAgent> GetByDepartment(string departmentId) {
      return _agents.SelectMany(p => p.Departments.Where(d => d.Id.Value.Equals(departmentId, StringComparison.OrdinalIgnoreCase)).Select(_ => p));
    }

    public IEnumerable<IAgent> GetByManager(string managerId) {
      return _agents.Where(p => p.Manager.Id.Value.Equals(managerId, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<IAgent> GetFiltered(Predicate<IAgent> filter) {
      return _agents.Where(d => filter(d));
    }

    public void RemoveAgent(IAgent agent) {
      _agents.Remove(agent);
    }

    public void RemoveAgent(string keyId) {
      var agent = this[keyId];
      if (agent != null) {
        _agents.Remove(agent);
      }
    }

    public void UpdateAgent(IAgent agent) {
      throw new NotImplementedException();
    }
  }

}
