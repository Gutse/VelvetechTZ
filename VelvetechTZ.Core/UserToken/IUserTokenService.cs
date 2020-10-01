using System.Threading.Tasks;
using VelvetechTZ.Domain.UserToken;

namespace VelvetechTZ.Core.UserToken
{
    public interface IUserTokenService
    {
        Task<UserTokenModel> Get(long userTokenId);
        Task<UserTokenModel> GetByToken(string token);
        Task<long> Create(UserTokenModel token);
        Task<long> Delete(long userTokenId);
        Task<long> DeleteByToken(string token);
        Task DeleteAllForUser(string token);
    }
}
