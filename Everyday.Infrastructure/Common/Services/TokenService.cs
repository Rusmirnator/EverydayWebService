using Everyday.Application.Common.Interfaces.Services;
using Everyday.Application.Common.Interfaces.Structures;
using Everyday.Application.Common.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Everyday.Infrastructure.Common.Services
{
    public class TokenService : ITokenService
    {
        #region Fields & Properties
        public ITokenOptions? Options { get; set; }
        #endregion

        #region CTOR
        public TokenService() { }
        #endregion

        #region Public API
        public string BuildToken(UserResponseModel user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            foreach (string role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(Options!.Key));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken tokenDescriptor = new(Options.Issuer, Options.Audience, claims,
                expires: DateTime.Now.AddMinutes(Options.LifetimeMinutes), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public bool ValidateToken(string encodedToken)
        {
            if (Options is null)
            {
                throw new ApplicationException($"{nameof(TokenService)} is not configured correctly!");
            }

            byte[] secret = Encoding.UTF8.GetBytes(Options.Key);
            SymmetricSecurityKey mySecurityKey = new(secret);
            JwtSecurityTokenHandler tokenHandler = new();

            try
            {
                tokenHandler.ValidateToken(encodedToken,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Options.Issuer,
                    ValidAudience = Options.Audience,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
