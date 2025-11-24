using digiuserslib.Model;

namespace digiuserslib;

public interface IPerson : IRecord, IInvalid {

  IName Name { get; }

  List<IMailAddress> EmailAdresses { get; }
  TPhoneNumbers PhoneNumbers { get; }
  List<ILocation> Locations { get; }
  TDepartments Departments { get; }
  
  string Company { get; }
  string Title { get; }

  IPicture Picture { get; }

  string Notes { get; }

}
