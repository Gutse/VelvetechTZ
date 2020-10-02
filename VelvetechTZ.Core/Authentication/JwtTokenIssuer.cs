using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace VelvetechTZ.Core.Authentication
{
    public class JwtTokenIssuer : IJwtTokenIssuer
    {
        public const string DefaultIssuerAudience = "https://velvetech.test.com";

        public (string Token, DateTime ExpirationTime) IssueToken(long userIdentityId, long userId)
        {
            return IssueToken(userIdentityId, userId, "conf.JwtSecretKey", TimeSpan.FromDays(365));
        }

        private (string Token, DateTime ExpirationTime) IssueToken(long userIdentityId, long userId, string secretKey, TimeSpan expiration)
        {
            var authClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, userIdentityId.ToString(CultureInfo.InvariantCulture)),
                new Claim("user_id", userId.ToString(CultureInfo.InvariantCulture))
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var token = new JwtSecurityToken(
                issuer: DefaultIssuerAudience,
                audience: DefaultIssuerAudience,
                expires: DateTime.UtcNow.Add(expiration),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return (tokenValue, token.ValidTo);
        }
    }
}