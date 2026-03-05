using System.ComponentModel.DataAnnotations;

namespace digiuserslib.Data.Entities;

public class EFLocationBasic {

  [Key, MaxLength(50)]
  public string Id { get; set; } = string.Empty;

  [Required, MaxLength(200)]
  public string Name { get; set; } = string.Empty;

  [Required, MaxLength(200)]
  public string Address1 { get; set; } = string.Empty;

  [Required, MaxLength(20)]
  public string Number { get; set; } = string.Empty;

  [MaxLength(200)]
  public string Address2 { get; set; } = string.Empty;

  [MaxLength(500)]
  public string AddressDetails { get; set; } = string.Empty;
  
  [Required, MaxLength(100)]
  public string City { get; set; } = string.Empty;

  [Required, MaxLength(20)]
  public string ZipCode { get; set; } = string.Empty;

  [Required, MaxLength(100)]
  public string Country { get; set; } = string.Empty;

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public EFLocationBasic() { }
  public EFLocationBasic(EFLocationBasic basic) {
    Id = basic.Id;
    Name = basic.Name;
    Address1 = basic.Address1;
    Number = basic.Number;
    Address2 = basic.Address2;
    AddressDetails = basic.AddressDetails;
    City = basic.City;
    ZipCode = basic.ZipCode;
    Country = basic.Country;
  } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}