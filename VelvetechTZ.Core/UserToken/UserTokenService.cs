using System.Threading.Tasks;
using VelvetechTZ.Contract.Errors;
using VelvetechTZ.DAL.Models.UserToken;
using VelvetechTZ.DAL.UserToken;

namespace VelvetechTZ.Core.UserToken
{
    public class UserTokenService : IUserTokenService
    {
        private readonly IUserTokenRepository userTokenRepository;

        public UserTokenService(IUserTokenRepository userTokenRepository)
        {
            this.userTokenRepository = userTokenRepository;
        }

        public async Task<UserTokenModel> GetByToken(string token)
        {
            var userToken = await userTokenRepository.GetByToken(token);

            if (userToken == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return userToken;
        }

        public async Task<long> Create(UserTokenModel token)
        {
            return await userTokenRepository.Insert(token.UserIdentityId, token.Token, token.Expiration);
        }

        public Task DeleteByToken(string token)
        {
            return userTokenRepository.Delete(token);
        }
    }
}
