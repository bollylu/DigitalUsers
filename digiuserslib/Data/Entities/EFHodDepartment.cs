namespace digiuserslib.Data.Entities;

/// <summary>
/// Represents the relationship between a contact and a department as a Head of Department (HOD).
/// This entity is used to associate a contact with a department in the role of a head, allowing for the representation of organizational
/// structure and leadership within the database.
/// Each instance of EFHodDepartment links a contact to a specific department, indicating that the contact is responsible for or leads that department.
/// </summary>
public class EFHodDepartment {
  public string ContactId { get; set; } = string.Empty;
  public EFContact Contact { get; set; } = null!;

  public string DepartmentId { get; set; } = string.Empty;
  public EFDepartment Department { get; set; } = null!;
}
