using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class ClaimExtensions
{
    public static void AddEmail(this ICollection<Claim> claims, string email)
    {
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
    }

    public static void AddName(this ICollection<Claim> claims, string firstName)
    {
        claims.Add(new Claim(ClaimTypes.Name, firstName));
    }

    public static void AddSurname(this ICollection<Claim> claims, string lastName)
    {
        claims.Add(new Claim(ClaimTypes.Surname, lastName));
    }

    public static void AddNameIdentifier(this ICollection<Claim> claims, int id)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
    }

    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
    }
}
