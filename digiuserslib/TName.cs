namespace digiuserslib;

public class TName : IName {
  public string FullName => $"{FirstName} {LastName}";
  public string FirstName { get; set; } = "";
  public string LastName { get; set; } = "";

  public TName() { }
  public TName(string firstName, string lastName) {
    FirstName = firstName;
    LastName = lastName;
  }
}
