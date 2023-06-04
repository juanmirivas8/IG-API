using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGAPI.Models;
[Table("Applications")]
public class ApplicationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public virtual CandidateEntity Candidate { get; set; }
    public virtual PositionEntity Position { get; set; }
    public virtual ApplicationStatusEntity Status { get; set; }
    public string RejectionReason { get; set; }
    public string Description { get; set; }
    // TO IMPLEMENT:TECHNICAL TEST PDF REFERENCE
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        ApplicationEntity applicationEntity = (ApplicationEntity)obj;
        return (Id == applicationEntity.Id);
    }
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            return hash;
        }
    }
}