using IGAPI.Dtos.ApplicationStatus;
using IGAPI.Dtos.Candidate;
using IGAPI.Dtos.Position;


namespace IGAPI.Dtos.Application
{
    public class ApplicationPostDto
    {
        public CandidatePutDto Candidate { get; set; }
        public PositionPutDto Position { get; set; }
        public ApplicationStatusResponseDto Status { get; set; }
        public string RejectionReason { get; set; }
        public string Description { get; set; }
    }
}
