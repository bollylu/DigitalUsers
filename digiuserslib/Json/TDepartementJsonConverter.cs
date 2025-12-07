using System;
using System.Text.Json;
using System.Text.Json.Serialization;

using BLTools;
using BLTools.Diagnostic.Logging;
using BLTools.Json;

namespace digiuserslib.Json;

public class TDepartementJsonConverter : JsonConverter<RDepartment>, ILoggable {

  public ILogger Logger { get; set; } = new TConsoleLogger() { Name = nameof(TDepartementJsonConverter) };

  public override bool CanConvert(Type typeToConvert) {
    return typeToConvert == typeof(RDepartment) || typeToConvert == typeof(IDepartment);
  }

  public override RDepartment? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
    try {
      if (reader.TokenType != JsonTokenType.StartObject) {
        Logger.LogErrorBox("Unable to read Department data **", reader.TokenType);
        throw new JsonException();
      }

      RDepartment RetVal = new();

      while (reader.Read()) {
        if (reader.TokenType == JsonTokenType.EndObject) {
          return RetVal;
        }

        if (reader.TokenType == JsonTokenType.PropertyName) {
          string PropertyName = reader.GetString() ?? string.Empty;
          PropertyName = $"{PropertyName.Left(1).ToUpperInvariant()}{PropertyName[1..]}";
          Logger.Log($"Processing {PropertyName.WithQuotes()}");
          reader.Read();

          switch (PropertyName) {
            case nameof(RDepartment.Id):
              RetVal.Id = new TKeyId(reader.GetString() ?? string.Empty);
              break;
            case nameof(RDepartment.Name):
              RetVal.Name = reader.GetString() ?? string.Empty;
              break;
            case nameof(RDepartment.Description):
              RetVal.Description = reader.GetString() ?? string.Empty;
              break;
            case nameof(RDepartment.HeadOfDepartment):
              //RetVal.HeadOfDepartment = [new TKeyId(reader.GetString() ?? string.Empty)];
              break;
            default:
              Logger.LogWarningBox("Department unknown property ** : ", PropertyName);
              // consume unknown value
              _ = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
              break;
          }
        }
      }

      return null;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to read Department data", ex);
      return null;
    }
  }

  public override void Write(Utf8JsonWriter writer, RDepartment value, JsonSerializerOptions options) {
    writer.WriteStartObject();

    writer.WriteString(nameof(RDepartment.Id), value.Id.Value);
    writer.WriteString(nameof(RDepartment.Name), value.Name);

    if (!string.IsNullOrWhiteSpace(value.Description)) {
      writer.WriteString(nameof(RDepartment.Description), value.Description);
    }

    if (value.HeadOfDepartment.Any()) {
      writer.WriteStartArray(nameof(RDepartment.HeadOfDepartment));
      foreach (IContactBasic ContactItem in value.HeadOfDepartment) {
        writer.WriteString(nameof(RDepartment.HeadOfDepartment), ContactItem.Id.Value);
      }
      writer.WriteEndArray();
    }

    writer.WriteEndObject();
  }
}
