namespace digiuserslib.Json;

public class TMailAddressesJsonConverter : JsonConverter<List<RMailAddress>>, ILoggable {

  public ILogger Logger { get; set; } = new TTraceLogger() { Name = nameof(TAgentJsonConverter) };

  public override bool CanConvert(Type typeToConvert) {
    return typeToConvert == typeof(List<RMailAddress>) || typeToConvert.IsInstanceOfType(typeof(IEnumerable<RMailAddress>));
  }

  public override List<RMailAddress> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
    List<RMailAddress> RetVal = new();

    try {

      if (reader.TokenType != JsonTokenType.StartArray) {
        Logger.LogErrorBox("Unable to read Email addresses data **", reader.TokenType);
        throw new JsonException();
      }

      while (reader.Read()) {

        if (reader.TokenType == JsonTokenType.EndArray) {
          return RetVal;
        }

        RMailAddress? MailAddress = JsonSerializer.Deserialize<RMailAddress>(ref reader, options);
        if (MailAddress is not null) {
          RetVal.Add(MailAddress);
        } else {
          Logger.LogWarning("Received null email address");
        }
      }

    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to read Agent data", ex);

    }

    return RetVal;

  }

  public override void Write(Utf8JsonWriter writer, List<RMailAddress> value, JsonSerializerOptions options) {
    writer.WriteStartArray();
    foreach (IMailAddress EmailItem in value) {
      if (EmailItem.IsValid) {
        JsonSerializer.Serialize(writer, EmailItem, options);
      }
    }
    writer.WriteEndArray();
  }

}
