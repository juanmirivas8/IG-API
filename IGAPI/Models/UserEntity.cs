using System.ComponentModel.DataAnnotations.Schema;

namespace IGAPI.Models;
[Table("Users")]
public class UserEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}