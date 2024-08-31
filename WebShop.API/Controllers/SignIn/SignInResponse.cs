using System.Diagnostics.CodeAnalysis;

namespace WebShop.API.Controllers.SignIn;

[SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
public record SignInResponse(string AccessToken, string RefreshToken);