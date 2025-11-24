namespace digiuserslib;

public interface IPerson : IRecord, IInvalid, IHierarchy {

  IName Name { get; }

  List<IMailAddress> EmailAdresses { get; }
  TPhoneNumbers PhoneNumbers { get; }
  List<ILocation> Locations { get; }
  TDepartments Departments { get; }
  IHierarchy? DependsOn { get; }

  string Company { get; }
  string Title { get; }

  IPicture Picture { get; }

  string Notes { get; }

}
