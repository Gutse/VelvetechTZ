using System;
using System.Globalization;
using System.Security.Claims;
using System.Text;

namespace VelvetechTZ.Core.Authentication
{
    public class JwtTokenIssuer : IJwtTokenIssuer
    {
        public const string DefaultIssuerAudience = "https://pm3.platfoza.com";

        private readonly IAppConfigurationReader appConfigurationReader;

        public JwtTokenIssuer(IAppConfigurationReader appConfigurationReader)
        {
            this.appConfigurationReader = appConfigurationReader;
        }

        public (string Token, DateTime ExpirationTime) IssueStartToken(long campaignId, long userId)
        {
            var conf = appConfigurationReader.Get();

            if (conf.JwtStartSecretKey == null)
                throw new ServiceException(AppErrors.ArgumentError);

            return IssueToken(campaignId, userId, conf.JwtStartSecretKey, conf.JwtStartTokenExpiration);
        }

        public (string Token, DateTime ExpirationTime) IssueToken(long userIdentityId, long userId)
        {
            var conf = appConfigurationReader.Get();

            if (conf.JwtSecretKey == null)
                throw new ServiceException(AppErrors.ArgumentError);

            return IssueToken(userIdentityId, userId, conf.JwtSecretKey, conf.JwtTokenExpiration);
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