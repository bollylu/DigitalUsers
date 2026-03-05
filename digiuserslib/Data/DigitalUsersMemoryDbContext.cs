using Microsoft.EntityFrameworkCore;

namespace digiuserslib.Data;

public class DigitalUsersMemoryDbContext : ADigitalUsersDbContext {

  public DigitalUsersMemoryDbContext(DbContextOptions<DigitalUsersMemoryDbContext> options) : base(options) {
  }

}