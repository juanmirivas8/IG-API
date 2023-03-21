using System.Text.Json.Serialization;

namespace IGAPI.Models.enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubRolEnum
{
    BackEnd,
    FrontEnd,
    Data
}