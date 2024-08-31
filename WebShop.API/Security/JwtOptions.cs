using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebShop.API.Security;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class JwtOptions
{
    [Required]
    public string Issuer { get; set; } = null!;

    [Required] 
    public string Audience { get; set; } = null!;
    
    [Required]
    public string SigningKey { get; set; }= null!;
}