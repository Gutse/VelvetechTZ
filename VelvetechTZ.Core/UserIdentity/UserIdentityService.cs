using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace VelvetechTZ.Core.UserIdentity
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IUserIdentityRepository userIdentityRepository;
        private readonly IUserTokenRepository userTokenRepository;
        private readonly UserIdentityContractValidator userIdentityContractValidator;
        private readonly IMapper mapper;
        private readonly IOffsetCalculator offsetCalculator;

        public UserIdentityService(
            IUserIdentityRepository userIdentityRepository,
            UserIdentityContractValidator userIdentityContractValidator,
            IMapper mapper, IOffsetCalculator offsetCalculator,
            IUserTokenRepository userTokenRepository)
        {
            this.userIdentityRepository = userIdentityRepository;
            this.userIdentityContractValidator = userIdentityContractValidator;
            this.mapper = mapper;
            this.offsetCalculator = offsetCalculator;
            this.userTokenRepository = userTokenRepository;
        }

        public async Task<List<UserIdentityContract>> GetAll(PageContract page)
        {
            var (offset, fetch) = offsetCalculator.Calculate(page.Page, page.PageSize);
            var userIdentities = await userIdentityRepository.GetAll(offset, fetch);

            return mapper.Map<List<UserIdentityEntity>, List<UserIdentityContract>>(userIdentities);
        }

        public async Task<UserIdentityContract> Get(long userIdentityId)
        {
            var userIdentity = await userIdentityRepository.Get(userIdentityId);

            if (userIdentity == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return mapper.Map<UserIdentityEntity, UserIdentityContract>(userIdentity);
        }

        public async Task<List<UserIdentityContract>> GetForUser(string email)
        {
            var userIdentities = await userIdentityRepository.GetForUser(email);

            if (userIdentities.Count == 0)
                throw new ServiceException(AppErrors.UserDontHaveIdentity);

            return mapper.Map<List<UserIdentityEntity>,List<UserIdentityContract>>(userIdentities);
        }

        public async Task<UserIdentityContract> GetDefault(long userId)
        {
            var user = await userIdentityRepository.GetDefault(userId);

            if (user == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return mapper.Map<UserIdentityEntity, UserIdentityContract>(user);
        }

        public async Task<long> Create(UserIdentityContract contract)
        {
            await userIdentityContractValidator.NullableValidateAndThrowAsync(contract);

            return await userIdentityRepository.Insert(contract.UserId, contract.IsDefault, contract.IdentityType,
                contract.Identity, contract.Salt);
        }

        public async Task<long> Update(UserIdentityContract contract)
        {
            await userIdentityContractValidator.NullableValidateAndThrowAsync(contract);

            var updated = await userIdentityRepository.Update(contract.UserIdentityId, contract.UserId, contract.IsDefault, contract.IdentityType,
                contract.Identity, contract.Salt);

            if (updated == 0)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return updated;
        }

        public async Task<long> Delete(long userIdentityId)
        {
            await userTokenRepository.DeleteForIdentity(userIdentityId);
            var deleted = await userIdentityRepository.Delete(userIdentityId);

            if (deleted == 0)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            return deleted;
        }
    }
}
