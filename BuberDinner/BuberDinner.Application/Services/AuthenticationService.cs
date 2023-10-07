using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Register(string firsName, string lastName, string email, string password)
    {
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firsName, lastName);
        return new AuthenticationResult(userId, firsName, lastName, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        //var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), firsName, lastName);
        return new AuthenticationResult(Guid.NewGuid(), "firsName", LastName: "lastName", email, "token");
    }
}
