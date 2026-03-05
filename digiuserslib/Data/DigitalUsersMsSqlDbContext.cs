using Microsoft.EntityFrameworkCore;

namespace digiuserslib.Data;

public class DigitalUsersMsSqlDbContext : ADigitalUsersDbContext {

  public DigitalUsersMsSqlDbContext(string connectionString)
    : base(new DbContextOptionsBuilder<DigitalUsersMsSqlDbContext>()
               .UseSqlServer(connectionString)
               .Options) {
  }
  public DigitalUsersMsSqlDbContext(DbContextOptions<DigitalUsersMsSqlDbContext> options) : base(options) {
  }

  public static DigitalUsersMsSqlDbContext Create(string connectionString) {
    return new DigitalUsersMsSqlDbContext(connectionString);

  }
}