using Everyday.Application.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Everyday.Infrastructure.Common.Services
{
    public class TokenService : ITokenService
    {
        private const double EXPIRY_DURATION_MINUTES = 480;

        public string BuildToken(string key, string issuer, string audience, object user)
        {
            List<Claim> claims = new()
            {
                //new Claim(ClaimTypes.Name, user.Login),
                //new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            //foreach (string role in user.Roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken tokenDescriptor = new(issuer, audience, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        public bool ValidateToken(string key, string issuer, string audience, string token)
        {
            byte[] secret = Encoding.UTF8.GetBytes(key);
            SymmetricSecurityKey mySecurityKey = new(secret);
            JwtSecurityTokenHandler tokenHandler = new();

            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
