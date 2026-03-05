using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace digiuserslib.Data.Entities;

public class EFDepartment : EFDepartmentBasic {
  public ICollection<EFContact> HeadsOfDepartment { get; set; } = [];
  public ICollection<EFContact> Contacts { get; set; } = [];

  

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public EFDepartment() : base() { }
  public EFDepartment(EFDepartmentBasic basic) : base(basic) { }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}