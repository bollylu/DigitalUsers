using System.ComponentModel.DataAnnotations;

namespace digiuserslib.Data.Entities;

public class EFContactBasic {

  [Key, MaxLength(50)]
  public string Id { get; set; } = string.Empty;

  [Required, MaxLength(100)]
  public string FirstName { get; set; } = string.Empty;
  
  [Required, MaxLength(100)]
  public string LastName { get; set; } = string.Empty;

  [MaxLength(200)]
  public string Company { get; set; } = string.Empty;

  [MaxLength(200)]
  public string Title { get; set; } = string.Empty;

  [MaxLength(1000)]
  public string Notes { get; set; } = string.Empty;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public EFContactBasic() { }
  public EFContactBasic(EFContactBasic other) {
    Id = other.Id;
    FirstName = other.FirstName;
    LastName = other.LastName;
    Company = other.Company;
    Title = other.Title;
    Notes = other.Notes;
  } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}