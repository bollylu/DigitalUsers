using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using BLTools;
using BLTools.Diagnostic.Logging;
using BLTools.Json;
using digiuserslib.Model;

namespace digiuserslib.Json;
public class TAgentJsonConverter : JsonConverter<RContact>, ILoggable {

  public ILogger Logger { get; set; } = new TConsoleLogger() { Name = nameof(TAgentJsonConverter) };

  public override bool CanConvert(Type typeToConvert) {
    return typeToConvert == typeof(RContact) || typeToConvert == typeof(IContact);
  }

  public override RContact? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
    try {

      if (reader.TokenType != JsonTokenType.StartObject) {
        Logger.LogErrorBox("Unable to read Agent data **", reader.TokenType);
        throw new JsonException();
      }

      RContact RetVal = new();

      while (reader.Read()) {

        if (reader.TokenType == JsonTokenType.EndObject) {
          return RetVal;
        }

        if (reader.TokenType == JsonTokenType.PropertyName) {
          string PropertyName = reader.GetString() ?? "";
          PropertyName = $"{PropertyName.Left(1).ToUpperInvariant()}{PropertyName[1..]}";
          Logger.Log($"Processing {PropertyName.WithQuotes()}");
          reader.Read();

          switch (PropertyName) {
            case nameof(RContact.Id):
              RetVal.Id = reader.GetString() ?? "";
              break;
            case nameof(RContact.EmailAdresses):
              RetVal.EmailAdresses.AddRange(JsonSerializer.Deserialize<List<RMailAddress>>(ref reader, options) ?? []);
              break;
            case nameof(RContact.PhoneNumbers):
              RetVal.PhoneNumbers.AddRange(JsonSerializer.Deserialize<List<RPhoneNumber>>(ref reader, options) ?? []);
              break;
            case nameof(RContact.Locations):
              RetVal.Locations.AddRange(JsonSerializer.Deserialize<List<RLocation>>(ref reader, options) ?? []);
              break;
            case nameof(RContact.Company):
              RetVal.Company = reader.GetString() ?? "";
              break;
            case nameof(RContact.Departments):
              RetVal.Departments.AddRange(JsonSerializer.Deserialize<List<RDepartment>>(ref reader, options) ?? []);
              break;
            case nameof(RContact.Notes):
              RetVal.Notes = reader.GetString() ?? "";
              break;
            case nameof(RContact.Title):
              RetVal.Title = reader.GetString() ?? "";
              break;
            case nameof(RContact.Picture):
              RetVal.Picture = JsonSerializer.Deserialize<RPicture>(ref reader, options) ?? new RPicture();
              break;
            default:
              Logger.LogWarningBox("Agent unknown property ** : ", PropertyName);
              break;
          }
        }
      }

      return null;
    } catch (Exception ex) {
      Logger.LogErrorBox("Unable to read Agent data", ex);
      return null;
    }

  }

  public override void Write(Utf8JsonWriter writer, RContact value, JsonSerializerOptions options) {

    writer.WriteStartObject();

    writer.WriteString(nameof(RContact.Id), value.Id);

    if (value.EmailAdresses.Any()) {
      writer.WritePropertyName(nameof(RContact.EmailAdresses));
      writer.WriteStartArray();
      foreach (IMailAddress EmailItem in value.EmailAdresses) {
        if (EmailItem.IsValid) {
          JsonSerializer.Serialize(writer, EmailItem, options);
        }
      }
      writer.WriteEndArray();
    }

    if (value.PhoneNumbers.Any()) {
      writer.WritePropertyName(nameof(RContact.PhoneNumbers));
      writer.WriteStartArray();
      foreach (IPhoneNumber PhoneItem in value.PhoneNumbers) {
        if (PhoneItem.IsValid) {
          JsonSerializer.Serialize(writer, PhoneItem, options);
        }
      }
      writer.WriteEndArray();
    }

    if (value.Locations.Any()) {
      writer.WritePropertyName(nameof(RContact.Locations));
      writer.WriteStartArray();
      foreach (ILocation LocationItem in value.Locations) {
        if (LocationItem.IsValid) {
          JsonSerializer.Serialize(writer, LocationItem, options);
        }
      }
      writer.WriteEndArray();
    }

    if (value.Departments.Any()) {
      writer.WritePropertyName(nameof(RContact.Departments));
      writer.WriteStartArray();
      foreach (IDepartment DepartmentItem in value.Departments) {
        if (DepartmentItem.IsValid) {
          JsonSerializer.Serialize(writer, DepartmentItem, options);
        }
      }
      writer.WriteEndArray();
    }

    writer.WritePropertyName(nameof(RContact.Picture));
    JsonSerializer.Serialize(writer, value.Picture, options);

    writer.WriteString(nameof(RContact.Company), value.Company);


    writer.WriteString(nameof(RContact.Notes), value.Notes);
    writer.WriteString(nameof(RContact.Title), value.Title);

    writer.WriteEndObject();
  }


}
