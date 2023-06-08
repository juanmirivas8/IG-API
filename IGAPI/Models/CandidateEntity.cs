
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGAPI.Models;
[Table("Candidates")]
public class CandidateEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public char Surname { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }
    public virtual CandidateStatusEntity Status { get; set; }
    public int ContactMethodId { get; set; }
    public virtual ContactMethodEntity ContactMethod { get; set; }
    [DataType(DataType.Date)]
    public DateTime CvDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime InterviewDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime TechnicalTestDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime FirstContactDate { get; set; }
    public virtual IEnumerable<ApplicationEntity> Applications { get; set; }
    // TO IMPLEMENT: LIST OF DOCUMENTS
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        CandidateEntity candidate = (CandidateEntity)obj;
        return (Id == candidate.Id);
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