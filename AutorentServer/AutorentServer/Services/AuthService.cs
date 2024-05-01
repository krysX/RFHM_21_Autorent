using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutorentServer.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace AutorentServer.Services;

public interface IAuthService
{
    public bool CheckForLogin(User user, string username, string password);
    public string GetHash(string password);
}


public class AuthService : IAuthService
{

    public AuthService()
    {
        
    }
    
    public bool CheckForLogin(User user, string username, string password)
    {
        string passwordHash = GetHash(password);
        return user.Username == username && user.PasswordHash == passwordHash;
    }

    public string GetHash(string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes;

        using (SHA256 sha256 = SHA256.Create())
        {
            hashBytes = sha256.ComputeHash(passwordBytes);
        }

        return Convert.ToBase64String(hashBytes);
    }

    public string GenerateJwtToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("eztNemFejtiMegSenki");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}