using DotNetCleanTemplate.Source.Infrastructure.Utils.Interfaces;

namespace DotNetCleanTemplate.Source.Infrastructure.Utils;

public class PasswordUtil : IPasswordUtil
{
    public string? HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return null;

        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hashedPassword))
            return false;

        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}