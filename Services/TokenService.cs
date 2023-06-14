using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MinhasFinancas.Models;
using MinhasFinancas.Settings;

namespace MinhasFinancas.Services;

public class TokenService
{
    private UserSettings _userSettings;

    public TokenService(IConfiguration config)
    {
        _userSettings = config.GetSection(UserSettings.TOKEN_SESSSION_NAME).Get<UserSettings>();
    }
    public string GenerateToken(User user){
        Claim[] claims = new Claim[] {
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_userSettings.TokenKey)
        );

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenMinTimeout = 60;

        JwtSecurityToken token  = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(tokenMinTimeout), //The token will expires in 10 minutes
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
