using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AutoDealer.JwtFeatures
{
    public class JwtHandler
    {
        private readonly IConfiguration configuration;
        private readonly IConfigurationSection jwtSettings;
        public JwtHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
            jwtSettings = this.configuration.GetSection("JwtSettings");
        }
        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        public List<Claim> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email!)
        };
            return claims;
        }
        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiryInMinutes"])),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
    }
}