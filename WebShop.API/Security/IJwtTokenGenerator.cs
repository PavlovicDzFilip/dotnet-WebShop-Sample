using WebShop.API.Controllers.SignIn;

namespace WebShop.API.Security;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
}