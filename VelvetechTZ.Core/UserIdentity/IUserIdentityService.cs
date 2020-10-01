using System.Collections.Generic;
using System.Threading.Tasks;

namespace VelvetechTZ.Core.UserIdentity
{
    public interface IUserIdentityService
    {
        Task<List<UserIdentityContract>> GetAll(PageContract page);
        Task<UserIdentityContract> Get(long userIdentityId);
        Task<List<UserIdentityContract>> GetForUser(string email);
        Task<UserIdentityContract> GetDefault(long userId);
        Task<long> Create(UserIdentityContract contract);
        Task<long> Update(UserIdentityContract contract);
        Task<long> Delete(long userIdentityId);
    }
}
