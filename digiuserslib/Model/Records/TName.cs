namespace digiuserslib.Model;

public class TName : IName {

  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;

  [JsonIgnore]
  public string FullName => $"{FirstName} {LastName}";

  [JsonIgnore]
  public bool IsInvalid => FullName.Trim() == string.Empty;

  public TName() { }
  public TName(string firstName, string lastName) {
    FirstName = firstName;
    LastName = lastName;
  }

}
