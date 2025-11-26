namespace digiuserslib.Model;

public interface ILocation : IRecord, IInvalid {

  string Name { get; }
  string Address1 { get; }
  string Address2 { get; }
  string AddressDetails { get; }
  string Number { get; }
  string City { get; }
  string ZipCode { get; }
  string Country { get; }

}
