using System;
using System.Threading.Tasks;
using VelvetechTZ.Contract.Errors;
using VelvetechTZ.Core.Password;
using VelvetechTZ.Core.User;
using VelvetechTZ.Core.UserToken;
using VelvetechTZ.DAL.Models.User;
using VelvetechTZ.DAL.Models.UserToken;

namespace VelvetechTZ.Core.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenIssuer jwtTokenIssuer;
        private readonly IUserService userService;
        private readonly IUserTokenService userTokenService;
        private readonly IPasswordService passwordService;

        public AuthenticationService
            (IJwtTokenIssuer jwtTokenIssuer,
            IUserService userService,
            IUserTokenService userTokenService,
            IPasswordService passwordService)
        {
            this.jwtTokenIssuer = jwtTokenIssuer;
            this.userService = userService;
            this.userTokenService = userTokenService;
            this.passwordService = passwordService;
        }

        public async Task<(string Token, DateTime ExpirationTime)> SignIn(long userId, string password)
        {
            var user = await userService.Get(userId);
            if (user == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            if (!passwordService.VerifyHashedPassword(user.Password, user.Salt, password))
                throw new ServiceException(AppErrors.BadLoginError);

            var (token, expirationTime) = jwtTokenIssuer.IssueToken(user.Id);

            await userTokenService.Create(new UserTokenModel { Expiration = expirationTime, Token = token, UserIdentityId = user.Id });

            return (token, expirationTime);
        }

        public async Task<long> SignUp(string name, string email, string password)
        {
            var user = await userService.GetByEmail(email);
            if (user != null)
                throw new ServiceException(AppErrors.UserAlreadyExists);

            var (hash, salt) = passwordService.GetNewPassword(password);

            var newUserContract = new UserModel { Email = email, Name = name, Password = hash, Salt = salt };

            return await userService.Create(newUserContract);
        }

        public Task SignOut(string token)
        {
            if (token == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return userTokenService.DeleteByToken(token);
        }
    }
}