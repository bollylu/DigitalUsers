using BLTools;
using digiuserslib.Model;

namespace digiuserslib {
  public class TDataSourceMemory : ADataSource {

    private readonly List<ITable> _Tables = [];

    #region --- Constructor(s) ---------------------------------------------------------------------------------
    public TDataSourceMemory() {
      _Initialize();
    }

    private TTablePersonsMemory? PersonsTable => (TTablePersonsMemory?)_Tables.FirstOrDefault(t => t is TTablePersonsMemory);

    private void _Initialize() {
      _Tables.Add(new TTablePersonsMemory());
      _Tables.Add(new TTablePhoneNumbersMemory());
      _Tables.Add(new TTableLocationsMemory());
      //_Tables.Add(new TTableMailAddressesMemory());
      //_Tables.Add(new TTableDepartmentsMemory());
    }
    #endregion --- Constructor(s) ------------------------------------------------------------------------------

    #region --- I/O Async -------------------------------------
    public override async ValueTask<bool> OpenAsync() {
      foreach (ITable TableItem in _Tables) {
        if (!await TableItem.OpenAsync().ConfigureAwait(false)) {
          Logger.LogError($"Unable to open table {TableItem.Name.WithQuotes()}");
          return false;
        }
      }
      return true;
    }

    public override async ValueTask<bool> CloseAsync() {
      foreach (ITable TableItem in _Tables) {
        if (!await TableItem.CloseAsync().ConfigureAwait(false)) {
          Logger.LogError($"Unable to close table {TableItem.Name.WithQuotes()}");
          return false;
        }
      }
      return true;
    }

    public override async ValueTask<bool> ReadAsync() {
      foreach (ITable TableItem in _Tables) {
        if (!await TableItem.ReadAsync().ConfigureAwait(false)) {
          Logger.LogError($"Unable to read table {TableItem.Name.WithQuotes()}");
          return false;
        }
      }
      return true;
    }

    public override async ValueTask<bool> SaveAsync() {
      foreach (ITable TableItem in _Tables) {
        if (!await TableItem.SaveAsync().ConfigureAwait(false)) {
          Logger.LogError($"Unable to save table {TableItem.Name.WithQuotes()}");
          return false;
        }
      }
      return true;
    }
    #endregion --- I/O -----------------------------------------

    #region --- I/O --------------------------------------------
    public override bool Open() {
      //foreach (ITable TableItem in _Tables) {
      //  if (!TableItem.Open()) {
      //    Logger.LogError($"Unable to open table {TableItem.Name.WithQuotes()}");
      //    return false;
      //  }
      //}
      return true;
    }

    public override bool Close() {
      //foreach (ITable TableItem in _Tables) {
      //  if (!TableItem.Close()) {
      //    Logger.LogError($"Unable to close table {TableItem.Name.WithQuotes()}");
      //    return false;
      //  }
      //}
      return true;
    }

    public override bool Read() {
      //foreach (ITable TableItem in _Tables) {
      //  if (!TableItem.Read()) {
      //    Logger.LogError($"Unable to read table {TableItem.Name.WithQuotes()}");
      //    return false;
      //  }
      //}
      return true;
    }

    public override bool Save() {
      //foreach (ITable TableItem in _Tables) {
      //  if (!TableItem.Save()) {
      //    Logger.LogError($"Unable to save table {TableItem.Name.WithQuotes()}");
      //    return false;
      //  }
      //}
      return true;
    }

    #endregion --- I/O -----------------------------------------

    public override async Task<IPerson?> GetPersonAsync(TKeyId id) {
      if (PersonsTable is null) {
        throw new ApplicationException("Persons table is not initialized.");
      }

      return await PersonsTable.GetAsync(id);
    }

    public override async IAsyncEnumerable<IPerson> GetPeopleAsync() {
      if (PersonsTable is null) {
        yield break;
      }

      await foreach (var person in PersonsTable.GetAllAsync()) {
        yield return person;
      }
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

    
  }
}
