namespace digiuserslib.Data.Entities;

public class EFLocation : EFLocationBasic {
  public ICollection<EFPicture> Pictures { get; set; } = [];
  public ICollection<EFContact> Contacts { get; set; } = [];

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public EFLocation() : base() { }
  public EFLocation(EFLocationBasic basic) : base(basic) { } 
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

}