using System.ComponentModel.DataAnnotations;

namespace digiuserslib.Data.Entities;

public class EFOrganizationBasic {

  [Key, MaxLength(50)]
  public string Id { get; set; } = string.Empty;
  
  [Required, MaxLength(100)]
  public string Name { get; set; } = string.Empty;
  
  [MaxLength(500)]
  public string Description { get; set; } = string.Empty;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public EFOrganizationBasic() { }
  public EFOrganizationBasic(EFOrganizationBasic basic) {
    Id = basic.Id;
    Name = basic.Name;
    Description = basic.Description;
  } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------
}