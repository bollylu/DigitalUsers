namespace digiuserslib.Model;

public interface ITableIO : ITable {
  bool Open();
  bool Close();
  bool Read();
  bool Save();

}
