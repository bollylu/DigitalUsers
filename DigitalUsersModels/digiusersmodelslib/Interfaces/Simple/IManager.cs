namespace digiusersmodelslib;

public interface IManager : IAgent {

  IEnumerable<IAgent> DirectReports { get; init; }
  

}
