namespace DotNetCleanTemplate.Source.Infrastructure.Utils.Interfaces;

public interface IPasswordUtil
{
    string? HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}