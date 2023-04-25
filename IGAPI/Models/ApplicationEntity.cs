using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGAPI.Models;

public class ApplicationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public virtual CandidateEntity Candidate { get; set; }
    public virtual PositionEntity Position { get; set; }
    public virtual ApplicationStatusEntity Status { get; set; }
    public string RejectionReason { get; set; }
    public string Description { get; set; }
    public int TechnicalTestId { get; set; }
}