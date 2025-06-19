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

namespace digiuserslib.Json;
public class TAgentJsonConverter : JsonConverter<TAgent>, ILoggable {

  public override bool CanConvert(Type typeToConvert) {
    return typeToConvert == typeof(TAgent) || typeToConvert == typeof(IPerson);
  }
  public override TAgent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
    try {

      if (reader.TokenType != JsonTokenType.StartObject) {
        Logger.LogErrorBox("Unable to read Agent data **", reader.TokenType);
        throw new JsonException();
      }

      TAgent RetVal = new();

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
            case nameof(TAgent.Id):
              RetVal.Id = reader.GetString() ?? "";
              break;
            case nameof(TAgent.Name):
              RetVal.Name = JsonSerializer.Deserialize<TName>(ref reader, options) ?? new TName();
              break;
            case nameof(TAgent.EmailPrimary):
              RetVal.EmailPrimary = JsonSerializer.Deserialize<TMailAddress>(ref reader, options) ?? TMailAddress.Empty;
              break;
            case nameof(TAgent.EmailSecondary):
              RetVal.EmailSecondary = JsonSerializer.Deserialize<TMailAddress>(ref reader, options) ?? TMailAddress.Empty;
              break;
            case nameof(TAgent.PhoneNumberPrimary):
              RetVal.PhoneNumberPrimary = JsonSerializer.Deserialize<TPhoneNumber>(ref reader, options) ?? TPhoneNumber.Empty;
              break;
            case nameof(TAgent.PhoneNumberSecondary):
              RetVal.PhoneNumberSecondary = JsonSerializer.Deserialize<TPhoneNumber>(ref reader, options) ?? TPhoneNumber.Empty;
              break;
            case nameof(TAgent.PhoneNumberMobile):
              RetVal.PhoneNumberMobile = JsonSerializer.Deserialize<TPhoneNumber>(ref reader, options) ?? TPhoneNumber.Empty;
              break;
            case nameof(TAgent.WorkLocationPrimary):
              RetVal.WorkLocationPrimary = JsonSerializer.Deserialize<TLocation>(ref reader, options) ?? TLocation.Empty;
              break;
            case nameof(TAgent.WorkLocationSecondary):
              RetVal.WorkLocationSecondary = JsonSerializer.Deserialize<TLocation>(ref reader, options) ?? TLocation.Empty;
              break;
            case nameof(TAgent.Company):
              RetVal.Company = reader.GetString() ?? "";
              break;
            case nameof(TAgent.Department):
              RetVal.Department = reader.GetString() ?? "";
              break;
            case nameof(TAgent.SubDepartment):
              RetVal.SubDepartment = reader.GetString() ?? "";
              break;
            case nameof(TAgent.Notes):
              RetVal.Notes = reader.GetString() ?? "";
              break;
            case nameof(TAgent.DependsOn):
              RetVal.DependsOn = reader.GetString() ?? "";
              break;
            case nameof(TAgent.Title):
              RetVal.Title = reader.GetString() ?? "";
              break;
            case nameof(TAgent.Picture):
              RetVal.Picture = JsonSerializer.Deserialize<TPicture>(ref reader, options) ?? new TPicture();
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

  public override void Write(Utf8JsonWriter writer, TAgent value, JsonSerializerOptions options) {
    writer.WriteStartObject();

    writer.WriteString(nameof(TAgent.Id), value.Id);

    writer.WritePropertyName(nameof(TAgent.Name));
    JsonSerializer.Serialize(writer, value.Name, options);

    writer.WritePropertyName(nameof(TAgent.EmailPrimary));
    JsonSerializer.Serialize(writer, value.EmailPrimary, options);

    writer.WritePropertyName(nameof(TAgent.EmailSecondary));
    JsonSerializer.Serialize(writer, value.EmailSecondary, options);

    if (!value.PhoneNumberPrimary.IsInvalid) {
      writer.WritePropertyName(nameof(TAgent.PhoneNumberPrimary));
      JsonSerializer.Serialize(writer, value.PhoneNumberPrimary, options);
    }

    if (!value.PhoneNumberSecondary.IsInvalid) {
      writer.WritePropertyName(nameof(TAgent.PhoneNumberSecondary));
      JsonSerializer.Serialize(writer, value.PhoneNumberSecondary, options);
    }

    if (!value.PhoneNumberMobile.IsInvalid) {
      writer.WritePropertyName(nameof(TAgent.PhoneNumberMobile));
      JsonSerializer.Serialize(writer, value.PhoneNumberMobile, options);
    }

    if (!value.WorkLocationPrimary.IsInvalid) {
      writer.WritePropertyName(nameof(TAgent.WorkLocationPrimary));
      JsonSerializer.Serialize(writer, value.WorkLocationPrimary, options);
    }

    if (!value.WorkLocationSecondary.IsInvalid) {
      writer.WritePropertyName(nameof(TAgent.WorkLocationSecondary));
      JsonSerializer.Serialize(writer, value.WorkLocationSecondary, options);
    }

    writer.WritePropertyName(nameof(TAgent.Picture));
    JsonSerializer.Serialize(writer, value.Picture, options);

    writer.WriteString(nameof(TAgent.Company), value.Company);
    writer.WriteString(nameof(TAgent.Department), value.Department);
    writer.WriteString(nameof(TAgent.SubDepartment), value.SubDepartment);
    writer.WriteString(nameof(TAgent.Notes), value.Notes);
    writer.WriteString(nameof(TAgent.DependsOn), value.DependsOn);
    writer.WriteString(nameof(TAgent.Title), value.Title);

    writer.WriteEndObject();
  }

  public ILogger Logger { get; set; } = new TConsoleLogger() { Name = nameof(TAgentJsonConverter) };
}
