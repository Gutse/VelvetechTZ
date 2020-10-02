using System;
using System.Threading.Tasks;
using VelvetechTZ.Core.Password;
using VelvetechTZ.Core.User;
using VelvetechTZ.Core.UserIdentity;
using VelvetechTZ.Core.UserToken;
using VelvetechTZ.Domain.Errors;
using VelvetechTZ.Domain.User;
using VelvetechTZ.Domain.UserIdentity;
using VelvetechTZ.Domain.UserToken;

namespace VelvetechTZ.Core.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenIssuer jwtTokenIssuer;
        private readonly IUserIdentityService userIdentityService;
        private readonly IUserService userService;
        private readonly IUserTokenService userTokenService;
        private readonly IPasswordService passwordService;

        public AuthenticationService
            (IJwtTokenIssuer jwtTokenIssuer,
            IUserIdentityService userIdentityService,
            IUserService userService,
            IUserTokenService userTokenService,
            IPasswordService passwordService)
        {
            this.jwtTokenIssuer = jwtTokenIssuer;
            this.userIdentityService = userIdentityService;
            this.userService = userService;
            this.userTokenService = userTokenService;
            this.passwordService = passwordService;
        }

        public async Task<(string Token, DateTime ExpirationTime)> SignIn(long userIdentityId, string password)
        {
            var userIdentity = await userIdentityService.Get(userIdentityId);
            if (userIdentity == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            if (!passwordService.VerifyHashedPassword(userIdentity.Identity,userIdentity.Salt, password))
                throw new ServiceException(AppErrors.BadLoginError);

            var (token, expirationTime) = jwtTokenIssuer.IssueToken(userIdentity.Id, userIdentity.UserId);

            await userTokenService.Create(new UserTokenModel { Expiration = expirationTime, Token = token, UserIdentityId = userIdentity.Id });

            return (token, expirationTime);
        }

        public async Task<long> SignUp(string name, string email, string password)
        {
            var user = await userService.GetByEmail(email);
            if (user != null)
                throw new ServiceException(AppErrors.UserAlreadyExists);

            var newUserContract = new UserModel() { Email = email, Name = name };

            var (hash, salt) = passwordService.GetNewPassword(password);

            var newUserId = await userService.Create(newUserContract);
            var newIdentityId = await userIdentityService.Create(new UserIdentityModel
            {
                UserId = newUserId,
                Salt = salt,
                Identity = hash
            });

            return newIdentityId;
        }

        public Task SignOut(string token)
        {
            //await userTokenService.DeleteByToken(token);
            throw new NotImplementedException();
        }

        public Task SignOutAll(string token)
        {
            if (token == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            //await userTokenService.DeleteAllForUser(token);
            throw new NotImplementedException();
        }
    }
}