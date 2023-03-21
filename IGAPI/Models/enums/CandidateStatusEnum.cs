using System.Text.Json.Serialization;

namespace IGAPI.Models.enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CandidateStatusEnum
{
    InProgress,
    Pendant,
    Rejected,
    Hired,
    Doubt
}