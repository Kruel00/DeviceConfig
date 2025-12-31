using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DeviceConfigUserData;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace DeviceConfigApi;

public class JwtTokenService
{
    private readonly IConfiguration _config;

    public JwtTokenService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> GetToke(User user, UserManager<User> userManager)
    {
        var jwt = _config.GetSection("jwt");

        var roles = await userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
          new(JwtRegisteredClaimNames.Sub, user.Id),
          new(JwtRegisteredClaimNames.Email, user.Email!),
          new(ClaimTypes.Name, user.UserName!)  
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["key"]!));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(
                int.Parse(jwt["ExpiresMinutes"]!)),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    

}
