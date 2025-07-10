using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCleanTemplate.Source.Domain.Entities.Auth;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid id;

    [Required]
    public required string Username;

    [Required]
    public required string Password;
        
    [MaxLength(64)]
    public required string FirstName;

    [MaxLength(64)]
    public required string LastName;
}
