using digiuserslib.Model;

namespace digiuserslib.Model;

public interface IContact : IContactBasic, IRecord, IInvalid, IName {

  TMailAddresses EmailAdresses { get; }
  TPhoneNumbers PhoneNumbers { get; }
  TLocations Locations { get; }
  TDepartments Departments { get; }

  IPicture Picture { get; }

}
