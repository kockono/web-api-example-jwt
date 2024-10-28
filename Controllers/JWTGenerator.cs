using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenGenerator
{
    public string GenerateToken(string userId, string userRole)
    {
        // Clave secreta que debe estar bien protegida en producción
        var secretKey = "la-llave-tiene-que-ser-larga-256bits"; // Cambia esto a una clave secreta segura 32 caracters o más
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Definir las claims (información del usuario)
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(ClaimTypes.Role, userRole),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Identificador único del token
        };

        // Crear el token JWT
        var token = new JwtSecurityToken(
            issuer: "your-app-name", // El nombre de tu aplicación o URL
            audience: "your-app-name", // Audiencia (tu aplicación)
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), // Tiempo de expiración del token
            signingCredentials: credentials);

        // Serializar el token y devolverlo
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
