using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Microsoft.IdentityModel.Tokens;
using VelvetechTZ.Core.UserToken;

namespace VelvetechTZ.Core.Authentication
{
    public class CustomTokenValidator : ISecurityTokenValidator
    {
        private readonly JwtSecurityTokenHandler tokenHandler;
        private readonly ILifetimeScope? container;
        private readonly IUserTokenService userTokenService;

        public CustomTokenValidator(ILifetimeScope? container)
        {
            this.container = container;
            tokenHandler = new JwtSecurityTokenHandler();

            if (container == null)
                throw new UndefinedArgumentException();

            userTokenService = container.Resolve<IUserTokenService>();
        }

        public bool CanReadToken(string securityToken)
        {
            return tokenHandler.CanReadToken(securityToken);
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters,
            out SecurityToken validatedToken)
        {
            var principal = tokenHandler.ValidateToken(securityToken, validationParameters, out validatedToken);

            var getTokenTask = Task.Run(() => userTokenService.GetByToken(securityToken));
            getTokenTask.Wait();

            var dbToken = getTokenTask.Result;

            if (dbToken == null || dbToken.Expiration < DateTime.UtcNow)
                throw new AuthenticationException("Token is invalid or expired");

            return principal;
        }

        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; } = TokenValidationParameters.DefaultMaximumTokenSizeInBytes;
    }
}
