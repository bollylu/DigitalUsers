namespace digiuserslib.Model;

public interface ITableHandling : ITable {
  bool Open();
  bool Close();
  bool Read();
  bool Save();

}
