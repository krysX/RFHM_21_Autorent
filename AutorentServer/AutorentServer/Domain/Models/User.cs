using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace AutorentServer.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }
}

public class UserLoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

// public UserPrincipal : ClaimsPrincipal {
//     
// }