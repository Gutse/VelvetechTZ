using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VelvetechTZ.DAL.UserToken;
using VelvetechTZ.Domain.UserIdentity;

namespace VelvetechTZ.Core.UserIdentity
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IUserTokenRepository userTokenRepository;
        //todo use repo in real
        private readonly List<UserIdentityModel> identities = new List<UserIdentityModel>();

        public UserIdentityService(IUserTokenRepository userTokenRepository)
        {
            this.userTokenRepository = userTokenRepository;
        }

        public Task<UserIdentityModel> GetDefault(long userId)
        {
            var user = identities.FirstOrDefault(u => u.UserId == userId);
            return Task.FromResult(user);
        }

        public Task<UserIdentityModel> Get(long userIdentityId)
        {
            var user = identities.FirstOrDefault(u => u.Id == userIdentityId);
            return Task.FromResult(user);
        }

        public Task<long> Create(UserIdentityModel contract)
        {
            identities.Add(contract);
            return Task.FromResult((long) identities.Count - 1);
        }
    }
}
