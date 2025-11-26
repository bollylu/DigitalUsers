namespace digiuserslib.Model;

public interface IMailAddress : IRecord, IInvalid {

  string Address { get; }
  string DisplayName { get; }
  int Order { get; }

}
