using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebShop.API.Security;

public static class SecurityExtensions
{
    public static void AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptionsSection = configuration.GetSection(nameof(JwtOptions));

        services.AddOptions<JwtOptions>()
            .Bind(jwtOptionsSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var jwtOptions = jwtOptionsSection.Get<JwtOptions>() ??
                         throw new Exception("Invalid JwtOptions");

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey))
                };
            });

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    }

    public static void UseSecurity(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}