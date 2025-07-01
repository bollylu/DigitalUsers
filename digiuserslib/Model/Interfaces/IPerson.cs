namespace digiuserslib;

public interface IPerson : IRecord, IInvalid, IHierarchy {

  IName Name { get; }

  List<IMailAddress> EmailAdresses { get; }
  List<IPhoneNumber> PhoneNumbers { get; }
  List<ILocation> Locations { get; }
  List<IDepartment> Departments { get; }
  IHierarchy? DependsOn { get; }

  string Company { get; }
  string Title { get; }

  IPicture Picture { get; }

  string Notes { get; }

}
