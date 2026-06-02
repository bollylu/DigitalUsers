namespace digiusersmodelslib;

public interface IDepartment : IRecord, IInvalid {
  
  string Name { get; }
  string Description { get; }
  IManager Manager { get; }
  IManager Deputy {  get; }
  IAgents Agents { get; }

}
