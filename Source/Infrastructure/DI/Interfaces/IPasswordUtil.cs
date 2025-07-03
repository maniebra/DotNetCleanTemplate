namespace DotNetCleanTemplate.Source.Infrastructure.DI.Interfaces;

public interface IPasswordUtil
{
    string? HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}