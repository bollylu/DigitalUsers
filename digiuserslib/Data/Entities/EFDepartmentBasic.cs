using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace digiuserslib.Data.Entities;

public class EFDepartmentBasic {

  [Key, MaxLength(50)]
  public string Id { get; set; } = string.Empty;
  
  [Required, MaxLength(100)]
  public string Name { get; set; } = string.Empty;
  
  [MaxLength(500)]
  public string Description { get; set; } = string.Empty;

  [Required]
  public string OrganizationId { get; set; } = null!;

  public EFOrganization Organization { get; set; } = null!;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public EFDepartmentBasic() { }
  public EFDepartmentBasic(EFDepartmentBasic basic) {
    Id = basic.Id;
    Name = basic.Name;
    Description = basic.Description;
    Organization = basic.Organization;
  } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}