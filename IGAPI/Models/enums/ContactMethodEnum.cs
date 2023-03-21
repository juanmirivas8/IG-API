using System.Text.Json.Serialization;

namespace IGAPI.Models.enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContactMethodEnum
{
    Agency,
    Direct,
    Referral
}