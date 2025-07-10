using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCleanTemplate.Source.Domain.Entities.Auth;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public required Guid Id { get; init; } = new Guid();

    [Required, MaxLength(64)]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }
        
    [MaxLength(64)]
    public required string FirstName { get; set; }

    [MaxLength(64)]
    public required string LastName { get; set; }

    [MaxLength(64), EmailAddress]
    public required string Email { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required DateTime CreatedAt { get; init; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public required DateTime? UpdatedAt { get; set; }

    public required Boolean IsAdmin  { get; set; } = false;
    public required Boolean IsStaff  { get; set; } = false;
    public required Boolean IsBanned { get; set; } = false;

    public static void Configure(EntityTypeBuilder<User> b)
    {
        b.ToTable("Users");
        
        b.HasIndex(u => u.Username)
            .IsUnique();

        b.HasIndex(u => u.Email)
            .IsUnique();
    }
}
