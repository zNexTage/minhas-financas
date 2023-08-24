using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.DTO.Token;
using Microsoft.IdentityModel.Tokens;
using MinhasFinancas.Models;
using MinhasFinancas.Settings;

namespace MinhasFinancas.Services;

public class TokenService
{
    private IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
 
    public ReadTokenDto GenerateToken(User user){
        var tokenKey = _configuration["TokenSettings:TokenKey"];

        Claim[] claims = new Claim[] {
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(tokenKey!)
        );

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenMinTimeout = 60;

        var expiresIn = DateTime.Now.AddMinutes(tokenMinTimeout);

        JwtSecurityToken token  = new JwtSecurityToken(
            expires: expiresIn, //The token will expires in 60 minutes
            claims: claims,
            signingCredentials: signingCredentials
        );

        var tokenDto = new ReadTokenDto();

        tokenDto.ExpiresIn = expiresIn;
        tokenDto.Token = new JwtSecurityTokenHandler().WriteToken(token);        

        return tokenDto;
    }
}
