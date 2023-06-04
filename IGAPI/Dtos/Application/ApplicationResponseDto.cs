using IGAPI.Dtos.ApplicationStatus;
using IGAPI.Dtos.Candidate;
using IGAPI.Dtos.Position;

namespace IGAPI.Dtos.Application;

public class ApplicationResponseDto
{
    public int Id { get; set; }
    public CandidateLazyResponseDto Candidate { get; set; }
    public PositionLazyResponseDto Position { get; set; }
    public ApplicationStatusResponseDto Status { get; set; }
    public string RejectionReason { get; set; }
    public string Description { get; set; }
}