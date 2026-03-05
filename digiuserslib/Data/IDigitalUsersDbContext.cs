using digiuserslib.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace digiuserslib.Data;

public interface IDigitalUsersDbContext : IDisposable {

  DatabaseFacade Database { get; }
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
  Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

  DbSet<EFOrganization> Organizations { get; }
  DbSet<EFContact> Contacts { get; }
  DbSet<EFPhoneNumber> PhoneNumbers { get; }
  DbSet<EFMailAddress> MailAddresses { get; }
  DbSet<EFLocation> Locations { get; }
  DbSet<EFPicture> Pictures { get; }
  DbSet<EFDepartment> Departments { get; }

}
