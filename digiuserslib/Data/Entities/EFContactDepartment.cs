namespace digiuserslib.Data.Entities;

/// <summary>
/// Represents the relationship between a contact and a department. 
/// This entity is used to associate a contact with a department, allowing for the representation of organizational structure within the database.
/// Each instance of EFContactDepartment links a contact to a specific department.
/// </summary>
public class EFContactDepartment {
  public string ContactId { get; set; } = string.Empty;
  public EFContact Contact { get; set; } = null!;

  public string DepartmentId { get; set; } = string.Empty;
  public EFDepartment Department { get; set; } = null!;

}