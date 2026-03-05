using Microsoft.EntityFrameworkCore;

namespace digiuserslib.Data;

public class DigitalUsersSqliteDbContext : ADigitalUsersDbContext {

  public DigitalUsersSqliteDbContext(string dbPath, string dbName)
    : base(new DbContextOptionsBuilder<DigitalUsersSqliteDbContext>()
               .UseSqlite($"Data Source={System.IO.Path.Combine(dbPath, dbName)}")
               .Options) {
  }

  public DigitalUsersSqliteDbContext(DbContextOptions<DigitalUsersSqliteDbContext> options) : base(options) {
  }

  public static DigitalUsersSqliteDbContext Create(string dbPath, string dbName) {
    return new DigitalUsersSqliteDbContext(dbPath, dbName);

  }

}