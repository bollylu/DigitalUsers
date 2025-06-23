using System.Text.Json.Serialization;

namespace digiuserslib;

public class TName : IName {
  [JsonIgnore]
  public string FullName => $"{FirstName} {LastName}";
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;

  public bool IsInvalid => FullName.Trim() == string.Empty;

  public TName() { }
  public TName(string firstName, string lastName) {
    FirstName = firstName;
    LastName = lastName;
  }
}
