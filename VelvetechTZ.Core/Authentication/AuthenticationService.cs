using System;
using System.Threading.Tasks;
using FluentValidation;

namespace VelvetechTZ.Core.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenIssuer jwtTokenIssuer;
        private readonly IUserIdentityService userIdentityService;
        private readonly IUserService userService;
        private readonly IUserTokenService userTokenService;
        private readonly IPasswordService passwordService;
        private readonly PasswordValidator passwordValidator;
        private readonly IUserRepository userRepository;
        private readonly UserContractValidator userContractValidator;
        private readonly IDbOperation dbOperation;
        private readonly IUserIdentityRepository userIdentityRepository;

        public AuthenticationService
            (IJwtTokenIssuer jwtTokenIssuer,
            IUserIdentityService userIdentityService,
            IUserService userService,
            IUserTokenService userTokenService,
            IPasswordService passwordService,
            PasswordValidator passwordValidator,
            IUserRepository userRepository,
            UserContractValidator userContractValidator,
            IDbOperation dbOperation,
            IUserIdentityRepository userIdentityRepository)
        {
            this.jwtTokenIssuer = jwtTokenIssuer;
            this.userIdentityService = userIdentityService;
            this.userService = userService;
            this.userTokenService = userTokenService;
            this.passwordService = passwordService;
            this.passwordValidator = passwordValidator;
            this.userRepository = userRepository;
            this.userContractValidator = userContractValidator;
            this.dbOperation = dbOperation;
            this.userIdentityRepository = userIdentityRepository;
        }

        public async Task<(string Token, DateTime ExpirationTime)> SignIn(long userIdentityId, string password)
        {
            var userIdentity = await userIdentityService.Get(userIdentityId);
            if (userIdentity == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            if (!passwordService.VerifyHashedPassword(userIdentity.Identity,userIdentity.Salt, password))
                throw new ServiceException(AppErrors.BadLoginError);

            var (token, expirationTime) = jwtTokenIssuer.IssueToken(userIdentity.UserIdentityId, userIdentity.UserId);

            await userTokenService.Create(new UserTokenContract { Expiration = expirationTime, Token = token, UserIdentityId = userIdentity.UserIdentityId });

            return (token, expirationTime);
        }

        public async Task<long> SignUp(string name, string email, string password)
        {
            var user = await userService.GetByEmail(email);
            if (user != null)
                throw new ServiceException(AppErrors.UserAlreadyExists);

            await passwordValidator.ValidateAndThrowAsync(password);

            var newUserContract = new UserContract { Email = email, Name = name };
            await userContractValidator.ValidateAndThrowAsync(newUserContract);

            var (hash, salt) = passwordService.GetNewPassword(password);

            return await dbOperation.Transaction(async (t) =>
            {
                var userId = await userRepository.Insert(newUserContract.Name, newUserContract.Email, t);

                return await userIdentityRepository.Insert(userId, true, 0,
                    hash, salt, t);
            });
        }

        public async Task SignOut(string token)
        {
            await userTokenService.DeleteByToken(token);
        }

        public async Task SignOutAll(string token)
        {
            if (token == null)
                throw new ServiceException(AppErrors.NullableRequestError);

            await userTokenService.DeleteAllForUser(token);
        }
    }
}