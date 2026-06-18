namespace digiusersmodelslib;

public class TContact : ARecord, IContact, IJson<TContact> {

  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;

  public ICompany Company { get; init; } = new TCompany();
  public string Title { get; set; } = string.Empty;
  public IPicture Picture { get; set; } = new TPicture();
  public string Notes { get; set; } = string.Empty;

  public IMailAddresses EmailAdresses { get; init; } = new TMailAddresses();
  public IPhoneNumbers PhoneNumbers { get; init; } = new TPhoneNumbers();
  public ILocations Locations { get; init; } = new TLocations();

  [JsonIgnore]
  public string FullName => $"{FirstName} {LastName}";

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(FullName);

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public TContact() {
  }
  public TContact(string id) {
    Id = id;
  }
  #endregion -------------------------------------------------------------------------------------------------

  #region --- IJson --------------------------------------------
  public TContact FromJson(string json) {
    return JsonSerializer.Deserialize<TContact>(json) ?? new TContact();
  }

  public static TContact CreateFromJson(string json) {
    return JsonSerializer.Deserialize<TContact>(json) ?? new TContact();
  }

  public string ToJson() {
    return JsonSerializer.Serialize(this, new JsonSerializerOptions() {
      WriteIndented = true,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    });
  } 
  #endregion --- IJson -----------------------------------------


}
