using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using IGAPI.Dtos.Application;
using IGAPI.Dtos.CandidateStatus;
using IGAPI.Dtos.ContactMethod;
using IGAPI.Models;

namespace IGAPI.Dtos.Candidate;

public class CandidatePostDto
{
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
    public virtual IEnumerable<ApplicationPostDto>? Applications { get; set; }
}

