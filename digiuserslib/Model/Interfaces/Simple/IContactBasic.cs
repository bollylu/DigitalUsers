using digiuserslib.Model;

namespace digiuserslib.Model;

public interface IContactBasic : IRecord, IInvalid, IName {

  string Company { get; }
  string Title { get; }

  string Notes { get; }

}
