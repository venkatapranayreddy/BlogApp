using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogApplication.Interfaces;
using BlogApplication.Models;
using Microsoft.IdentityModel.Tokens;

namespace BlogApplication.Repository
{
    public class TokenService : ITokenService
    {
        private readonly  IConfiguration _iConfiguration;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;
        public TokenService(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfiguration["JWT:SigningKey"]));


        }
        public string createToken(AppUser appUser)
        {
           var Claims = new List<Claim> 
           {
                new Claim(JwtRegisteredClaimNames.Email,appUser.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, appUser.UserName),
                // new Claim(JwtRegisteredClaimNames.Sub, appUser.UserName),
                // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // new Claim(ClaimTypes.NameIdentifier, appUser.Id)
                

           };
           var creds = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
           var tokenDescriptor = new SecurityTokenDescriptor
           {
             Subject = new ClaimsIdentity(Claims),
             Expires = DateTime.Now.AddDays(1),
             SigningCredentials = creds,
             Issuer = _iConfiguration["JWT:Issuer"],
             Audience = _iConfiguration["JWT:Audience"]
           };
           var tokenHandler = new JwtSecurityTokenHandler();
           var token = tokenHandler.CreateToken(tokenDescriptor);

           return tokenHandler.WriteToken(token);
        }
    }
}