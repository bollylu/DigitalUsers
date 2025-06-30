using BLTools;

namespace digiuserslib;

public record RMailAddress : ARecord, IMailAddress {
  public string Address { get; set; } = string.Empty;
  public string DisplayName { get; set; } = string.Empty;

  public static RMailAddress Empty => new RMailAddress();

  public override bool IsInvalid =>
    Id.IsInvalid ||
    Address.Trim() == string.Empty ||
    !Address.Contains('@') ||
    Address.Count('@') > 1 ||
    !Address.Contains('.') ||
    Address.Before('@').Trim() == string.Empty ||
    Address.After('.').Trim() == string.Empty ||
    Address.Between('@', '.').Trim() == string.Empty;
}
