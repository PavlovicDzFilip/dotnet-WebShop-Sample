namespace WebShop.API.Controllers.SignIn;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole Role { get; set; }
}