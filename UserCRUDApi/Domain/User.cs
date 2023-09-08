using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserCRUDApi.Domain;

[Table("users",Schema = "crud"),
 Index(nameof(Name),
     nameof(PhoneNumber),nameof(Email))]
public class User : BaseModel
{
    [Column("name")] public string Name { get; set; }
    [Column("surname")] public string Surname { get; set; }
    [Column("phone_number")] public string PhoneNumber { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("password")] public string Password { get; set; }
}