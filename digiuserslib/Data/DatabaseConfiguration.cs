namespace digiuserslib.Data;

public enum DatabaseProvider {
  SqlServer,
  Sqlite,
  PostgreSQL,
  MySql
}

public class DatabaseConfiguration {
  public DatabaseProvider Provider { get; set; } = DatabaseProvider.SqlServer;
  public string ConnectionString { get; set; } = string.Empty;
}