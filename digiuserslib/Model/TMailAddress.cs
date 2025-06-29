﻿namespace digiuserslib;

public class TMailAddress : IMailAddress {
  public string Address { get; set; } = string.Empty;
  public string DisplayName { get; set; } = string.Empty;

  public static TMailAddress Empty => new TMailAddress();

  public bool IsInvalid => Address.Trim() == string.Empty || !Address.Contains('@');
}
