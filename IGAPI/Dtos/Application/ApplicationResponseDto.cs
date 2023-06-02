using IGAPI.Dtos.ApplicationStatus;
using IGAPI.Dtos.Candidate;
using IGAPI.Dtos.Position;

namespace IGAPI.Dtos.Application;

public class ApplicationResponseDto
{
    public int Id { get; set; }
    public CandidateResponseDto Candidate { get; set; }
    public PositionResponseDto Position { get; set; }
    public ApplicationStatusResponseDto Status { get; set; }
    public string RejectionReason { get; set; }
    public string Description { get; set; }
}