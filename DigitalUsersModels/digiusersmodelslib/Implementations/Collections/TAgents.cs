namespace digiusersmodelslib {

  public class TAgents : IAgents {

    private readonly List<IAgent> _agents = [];

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TAgents() {
    }
    public TAgents(IEnumerable<IAgent> agents) {
      _agents.AddRange(agents);
    } 
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    public int Count => _agents.Count;
    public bool IsEmpty => _agents.IsEmpty();
    public bool Any() => _agents.Any();

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

    public IEnumerable<IAgent> GetByDepartment(TKeyId departmentId) {
      return _agents.Where(a => a.DepartmentsMemberOf.Any(d => d.Id.Equals(departmentId, StringComparison.OrdinalIgnoreCase)));
    }

    public IEnumerable<IAgent> GetByManager(TKeyId managerId) {
      return _agents.Where(p => p.Manager.Id.Value.Equals(managerId.Value, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<IAgent> GetFiltered(Predicate<IAgent> filter) {
      return _agents.Where(d => filter(d));
    }

    public void RemoveAgent(IAgent agent) {
      _agents.Remove(agent);
    }

    public void RemoveAgent(TKeyId keyId) {
      var agent = this[keyId.Value];
      if (agent != null) {
        _agents.Remove(agent);
      }
    }

    public void UpdateAgent(IAgent agent) {
      throw new NotImplementedException();
    }
  }

}
