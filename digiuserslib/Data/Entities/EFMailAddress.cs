namespace digiuserslib.Data.Entities;

public class EFMailAddress {
  public string Id { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;
  public string DisplayName { get; set; } = string.Empty;

  public ICollection<EFContact> Contacts { get; set; } = [];

}