namespace digiusersmodelslib;

public class TPhoneNumbers : ACollection<IPhoneNumber>, IPhoneNumbers {

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TPhoneNumbers() : base() { }
  public TPhoneNumbers(IEnumerable<IPhoneNumber> collection) : base(collection) { }
  #endregion --- Constructor(s) ------------------------------------------------------------------------------

  /// <summary>
  /// Gets the mobile phone number.
  /// </summary>
  /// <returns>The mobile phone number, or null if not found.</returns>
  public IPhoneNumber? MobilePhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Mobile);

  /// <summary>
  /// Gets the work phone number.
  /// </summary>
  /// <returns>The work phone number, or null if not found.</returns>
  public IPhoneNumber? WorkPhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Work);

  /// <summary>
  /// Gets the home phone number.
  /// </summary>
  /// <returns>The home phone number, or null if not found.</returns>
  public IPhoneNumber? HomePhoneNumber => this.FirstOrDefault(x => x.Type == EPhoneNumberType.Home);

}

