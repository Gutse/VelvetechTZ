using System.Threading.Tasks;
using VelvetechTZ.Domain.UserIdentity;

namespace VelvetechTZ.Core.UserIdentity
{
    public interface IUserIdentityService
    {
        Task<UserIdentityModel> GetDefault(long userId);
        Task<UserIdentityModel> Get(long userIdentityId);
        Task<long> Create(UserIdentityModel contract);
    }
}
