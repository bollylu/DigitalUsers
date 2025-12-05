namespace digiuserslib.Model;

public record RContactBasic : ARecord, IContactBasic {

  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;

  public string Company { get; set; } = string.Empty;
  public string Title { get; set; } = string.Empty;
  public string Notes { get; set; } = string.Empty;

  [JsonIgnore]
  public string FullName => $"{FirstName} {LastName}";

  [JsonIgnore]
  public override bool IsInvalid => base.IsInvalid || string.IsNullOrWhiteSpace(FullName);

  #region --- Constructor(s) ---------------------------------------------------------------------------------
  public RContactBasic() {
  }
  public RContactBasic(string id) {
    Id = id;
  }

  #endregion -------------------------------------------------------------------------------------------------

  public static RContactBasic BollyLuc => new("bollylu") {
    FirstName = "Luc",
    LastName = "Bolly",
    Company = "Ville de Seraing",
    Title = "Responsable IT",
    Notes = "Expert in customer support and troubleshooting."
  };

  public static RContactBasic MartinSophie => new("martiso") {
    FirstName = "Sophie",
    LastName = "Martin",
    Company = "Ville de Seraing",
    Title = "Technicienne IT",
    Notes = "Specializes in network infrastructure and maintenance.",
  };

  public static RContactBasic DupontJean => new("duponje") {
    FirstName = "Jean",
    LastName = "Dupont",
    Company = "Ville de Seraing",
    Title = "Analyste IT",
    Notes = "Focuses on system optimization and performance analysis.",
  };

  public static RContactBasic LefevreClaire => new("lefevcl") {
    FirstName = "Claire",
    LastName = "Lefevre",
    Company = "Ville de Seraing",
    Title = "Consultante IT",
    Notes = "Provides strategic IT consulting and project management.",
  };

  public static RContactBasic AdamBruno => new("adambr") {
    FirstName = "Bruno",
    LastName = "Adam",
    Company = "Ville de Seraing",
    Title = "Directeur général",
    Notes = "Dirige la boite",
  };
}
