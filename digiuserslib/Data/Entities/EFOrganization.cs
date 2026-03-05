namespace digiuserslib.Data.Entities;

public class EFOrganization : EFOrganizationBasic {

  public ICollection<EFContact> Contacts { get; set; } = [];
  public ICollection<EFDepartment> Departments { get; set; } = [];
  public ICollection<EFPicture> Pictures { get; set; } = [];
  public ICollection<EFLocation> Locations { get; set; } = [];

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public EFOrganization() : base() { }
  public EFOrganization(EFOrganizationBasic basic) : base(basic) { } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}
