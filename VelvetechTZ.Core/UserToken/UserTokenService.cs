using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace VelvetechTZ.Core.UserToken
{
    public class UserTokenService : IUserTokenService
    {
        private readonly IUserTokenRepository userTokenRepository;
        private readonly IMapper mapper;
        private readonly IOffsetCalculator offsetCalculator;

        public UserTokenService(
            IUserTokenRepository userTokenRepository, IMapper mapper, IOffsetCalculator offsetCalculator)
        {
            this.userTokenRepository = userTokenRepository;
            this.mapper = mapper;
            this.offsetCalculator = offsetCalculator;
        }

        public async Task<List<UserTokenContract>> GetAll(PageContract page)
        {
            var (offset, fetch) = offsetCalculator.Calculate(page.Page, page.PageSize);
            var userTokens = await userTokenRepository.GetAll(offset, fetch);

            return mapper.Map<List<UserTokenModel>, List<UserTokenContract>>(userTokens);
        }

        public async Task<UserTokenContract> Get(long userTokenId)
        {
            var userToken = await userTokenRepository.Get(userTokenId);

            if (userToken == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return mapper.Map<UserTokenModel, UserTokenContract>(userToken);
        }

        public async Task<UserTokenContract> GetByToken(string token)
        {
            var userToken = await userTokenRepository.GetByToken(token);

            if (userToken == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return mapper.Map<UserTokenModel, UserTokenContract>(userToken);
        }

        public UserTokenContract GetByTokenSync(string token)
        {
            var userToken = userTokenRepository.GetByTokenSync(token);
            return mapper.Map<UserTokenModel, UserTokenContract>(userToken);
        }

        public async Task<long> Create(UserTokenContract contract)
        {
            return await userTokenRepository.Insert(contract.UserIdentityId, contract.Token, contract.Expiration);
        }

        public async Task<long> Update(UserTokenContract contract)
        {
            var updated = await userTokenRepository.Update(contract.UserTokenId, contract.UserIdentityId, contract.Token, contract.Expiration);

            if (updated == 0)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return updated;
        }

        public async Task<long> Delete(long userTokenId)
        {
            var deleted = await userTokenRepository.Delete(userTokenId);

            if (deleted == 0)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return deleted;
        }

        public async Task<long> DeleteByToken(string token)
        {
            var deleted = await userTokenRepository.DeleteByToken(token);

            if (deleted == 0)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return deleted;
        }

        public async Task DeleteAllForUser(string token)
        {
            var deleted = await userTokenRepository.DeleteAllForUserByToken(token);

            if (deleted == 0)
                throw new ServiceException(AppErrors.EntityDoesNotExists);
        }
    }
}
