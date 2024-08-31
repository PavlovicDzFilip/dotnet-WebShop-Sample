using Microsoft.AspNetCore.Mvc;
using WebShop.API.Security;

namespace WebShop.API.Controllers.SignIn;

[ApiController]
[Route("[controller]")]
public class SignInController(IJwtTokenGenerator jwtTokenGenerator) : Controller
{
    private static readonly IEnumerable<User> Users = new List<User>()
    {
        new() { Email = "admin@webshop.com", Password = "admin123", Id = 1, Role = UserRole.Admin },
        new() { Email = "user@webshop.com", Password = "user123", Id = 2, Role = UserRole.User },
    };

    [HttpPost]
    public IActionResult Index(SignInRequest signInRequest)
    {
        // A simple mock implementation of a sign-in system
        var user = Users.FirstOrDefault(u => u.Email == signInRequest.Email && u.Password == signInRequest.Password);
        if (user is null)
        {
            return Unauthorized();
        }

        var token = jwtTokenGenerator.GenerateAccessToken(user);
        var response = new SignInResponse(token, token);

        return Ok(response);
    }
}