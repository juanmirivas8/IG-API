using System.ComponentModel.DataAnnotations;
using IGAPI.Dtos.CandidateStatus;
using IGAPI.Dtos.ContactMethod;

namespace IGAPI.Dtos.Candidate;

public class CandidateLazyResponseDto
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public char? Surname { get; set; }
    public string? Description { get; set; }
    public virtual CandidateStatusResponseDto? Status { get; set; }
    public virtual ContactMethodResponseDto? ContactMethod { get; set; }
    [DataType(DataType.Date)]
    public DateTime? CvDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? InterviewDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? TechnicalTestDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? FirstContactDate { get; set; }
}