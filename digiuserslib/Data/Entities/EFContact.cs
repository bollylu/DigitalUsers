using System.Diagnostics.CodeAnalysis;

namespace digiuserslib.Data.Entities;

public class EFContact : EFContactBasic {
  public ICollection<EFPhoneNumber> PhoneNumbers { get; set; } = [];
  public ICollection<EFMailAddress> MailAddresses { get; set; } = [];
  public ICollection<EFLocation> Locations { get; set; } = [];
  public ICollection<EFDepartment> Departments { get; set; } = [];
  public ICollection<EFDepartment> HodDepartments { get; set; } = [];
  public ICollection<EFPicture> Pictures { get; set; } = [];

  public string? OrganizationId { get; set; }

  public EFOrganization? Organization { get; set; }


  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public EFContact() { }
  public EFContact(EFContactBasic basic) {
    Id = basic.Id;
    FirstName = basic.FirstName;
    LastName = basic.LastName;
    Company = basic.Company;
    Title = basic.Title;
    Notes = basic.Notes;
  }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  
}