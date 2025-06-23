namespace digiuserslib;

public interface IPerson : IInvalid {

  string Id { get; }

  IName Name { get; }

  IMailAddress EmailPrimary { get; }
  IMailAddress EmailSecondary { get; }

  IPhoneNumber PhoneNumberPrimary { get; }
  IPhoneNumber PhoneNumberSecondary { get; }
  IPhoneNumber PhoneNumberMobile { get; }

  string Company { get; }
  string Title { get; }
  IDepartment Department { get; }
  IDepartment SubDepartment { get; }

  ILocation WorkLocationPrimary { get; }
  ILocation WorkLocationSecondary { get; }

  IPicture Picture { get; }

  string Notes { get; }

  string DependsOn { get; }

}
