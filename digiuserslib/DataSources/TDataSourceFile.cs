using System.Text.Json;
using System.Text.Json.Serialization;
using BLTools;

using digiuserslib.Json;

namespace digiuserslib;
public class TDataSourceFile : ADataSource, IDataSource {

  public const string DEFAULT_LOCATION = ".";

  public string DataFileLocation { get; set; } = DEFAULT_LOCATION;

  protected readonly List<ITable> _Tables = [];

  public ATable<ILocation> TableLocation =>
    _Tables.OfType<ATable<ILocation>>().SingleOrDefault() ??
    throw new InvalidOperationException("TableLocation is not initialized.");

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TDataSourceFile(string dataFileLocation = DEFAULT_LOCATION) {
    DataFileLocation = dataFileLocation;
    try {
      if (!Directory.Exists(DataFileLocation)) {
        Directory.CreateDirectory(DataFileLocation);
      }
    } catch (Exception ex) {
      throw new ApplicationException($"Unable to create directory {DataFileLocation.WithQuotes()}", ex);
    }
    _Tables.Add(new TTableLocationsFileWithCache(Path.Combine(DataFileLocation, "locations.json")));
  }

    public override Task<IPerson?> GetPersonAsync(TKeyId id) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPerson> GetPeopleAsync() {
        throw new NotImplementedException();
    }

    public override Task<IPerson?> GetPersonByPhoneNumberAsync(IPhoneNumber phoneNumber) {
        throw new NotImplementedException();
    }

    public override Task<IPerson?> GetPersonByEmailAsync(IMailAddress mailAddress) {
        throw new NotImplementedException();
    }

    public override Task<ILocation?> GetLocationAsync(string id) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<ILocation> GetLocationsAsync() {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<ILocation> GetLocationsByPersonAsync(string idPerson) {
        throw new NotImplementedException();
    }

    public override Task<IPhoneNumber?> GetPhoneNumberAsync(string id) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersAsync() {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPhoneNumber> GetPhoneNumbersByPersonAsync(string idPerson) {
        throw new NotImplementedException();
    }

    public override Task<IMailAddress?> GetMailAddressAsync(string id) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IMailAddress> GetMailAddressesAsync() {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IMailAddress> GetMailAddressesByPersonAsync(string idPerson) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPerson> GetPeopleByLocationAsync(ILocation location) {
        throw new NotImplementedException();
    }

    public override Task<IDepartment?> GetDepartmentAsync(string departmentId) {
        throw new NotImplementedException();
    }

    public override Task<IPerson?> GetHeadOfDepartmentAsync(string departmentId) {
        throw new NotImplementedException();
    }

    public override IAsyncEnumerable<IPerson> GetDepartmentMembersAsync(string departmentId) {
        throw new NotImplementedException();
    }

    public override ValueTask<bool> OpenAsync() {
        throw new NotImplementedException();
    }

    public override ValueTask<bool> CloseAsync() {
        throw new NotImplementedException();
    }

    public override ValueTask<bool> ReadAsync() {
        throw new NotImplementedException();
    }

    public override ValueTask<bool> SaveAsync() {
        throw new NotImplementedException();
    }

    public override bool Open() {
        throw new NotImplementedException();
    }

    public override bool Close() {
        throw new NotImplementedException();
    }

    public override bool Read() {
        throw new NotImplementedException();
    }

    public override bool Save() {
        throw new NotImplementedException();
    }

    #endregion --- Constructor(s) ------------------------------------------------------------------------------


}
