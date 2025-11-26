using digiuserslib.Model;

namespace digiuserslib.Model;

public interface IContact : IRecord, IInvalid, IName {

  TMailAddresses EmailAdresses { get; }
  TPhoneNumbers PhoneNumbers { get; }
  TLocations Locations { get; }
  TDepartments Departments { get; }

  string Company { get; }
  string Title { get; }

  IPicture Picture { get; }

  string Notes { get; }

}
