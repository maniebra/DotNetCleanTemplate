using DotNetCleanTemplate.Source.Domain.Entities.Auth;
using DotNetCleanTemplate.Source.Persistence.Repositories.Interfaces;
using DotNetCleanTemplate.Source.Infrastructure.Utils.Interfaces;
using DotNetCleanTemplate.Source.Infrastructure.Commons;
using DotNetCleanTemplate.Source.Domain.Services.Interfaces;


namespace DotNetCleanTemplate.Source.Domain.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordUtil _passwordUtil;
    private readonly IJwtUtil _jwtUtil;

    public AuthService(
        IUserRepository userRepository,
        IPasswordUtil passwordUtil,
        IJwtUtil jwtUtil)
    {
        _userRepository = userRepository;
        _passwordUtil = passwordUtil;
        _jwtUtil = jwtUtil;
    }

    public async Task<Result<string>> LoginUser(string username, string password)
    {
        var user = await _userRepository.GetUserByUsername(username);
        if (user == null)
            return Result<string>.Failure("Invalid credentials.");

        var isValid = _passwordUtil.VerifyPassword(password, user.Password);
        if (!isValid)
            return Result<string>.Failure("Invalid credentials.");

        var token = _jwtUtil.GenerateToken(user.Id, user.Username, user.IsAdmin, user.IsStaff);
        return Result<string>.Success(token);
    }

    public async Task<Result<User>> RegisterUser(string username,
                                                 string password,
                                                 string email,
                                                 string firstName,
                                                 string lastName)
    {
        try {
            var existingUser = await _userRepository.GetUserByUsername(username);
            if (existingUser != null)
                return Result<User>.Failure("Username already exists.");

            var passwordHash = _passwordUtil.HashPassword(password);

            if (passwordHash == null) throw new Exception("Setting password went wrong.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = passwordHash,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddNewUser(user);
            return Result<User>.Success(user);
        } catch (Exception e) { 
            return Result<User>.Failure(e);
        }
    }
}

