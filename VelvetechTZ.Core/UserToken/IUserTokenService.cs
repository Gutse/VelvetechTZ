using System.Threading.Tasks;
using VelvetechTZ.Domain.UserToken;

namespace VelvetechTZ.Core.UserToken
{
    public interface IUserTokenService
    {
        Task<UserTokenModel> GetByToken(string token);
        Task<long> Create(UserTokenModel token);
    }
}
