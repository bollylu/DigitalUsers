namespace digiusersmodelslib;

public interface IContact : IRecord, IInvalid, IName {

  IMailAddresses EmailAdresses { get; }
  IPhoneNumbers PhoneNumbers { get; }
  ILocations Locations { get; }
  
  ICompany Company { get; }
  string Title { get; }

  IPicture Picture { get; }

  string Notes { get; }

}
