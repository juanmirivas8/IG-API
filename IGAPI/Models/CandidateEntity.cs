
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IGAPI.Models.enums;

namespace IGAPI.Models;

public class CandidateEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public char Surname { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public virtual CandidateStatusEntity Status { get; set; }
    public int StatusId { get; set; }
    public virtual ContactMethodEntity ContactMethod { get; set; }
    public int ContactMethodId { get; set; }
    public DateTime CvDate { get; set; }
    public DateTime InterviewDate { get; set; }
    public DateTime TechnicalTestDate { get; set; }
    public DateTime FirstContactDate { get; set; }
}