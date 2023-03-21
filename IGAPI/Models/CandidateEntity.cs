
using IGAPI.Models.enums;

namespace IGAPI.Models;

public class CandidateEntity
{
    public int ID { get; set; }
    public string Name { get; set; }
    public char Surname { get; set; }
    public string Description { get; set; }
    public string RejectionReason { get; set; }
    public CandidateStatusEnum Status { get; set; }
    public ContactMethodEnum ContactMethod { get; set; }
    public DateTime CvDate { get; set; }
    public DateTime InterviewDate { get; set; }
    public DateTime TechnicalTestDate { get; set; }
    public DateTime FirstContactDate { get; set; }
    public RolEntity Rol { get; set; }
}