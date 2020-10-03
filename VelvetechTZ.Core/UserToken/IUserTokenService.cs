using System.Threading.Tasks;
using VelvetechTZ.DAL.Models.UserToken;

namespace VelvetechTZ.Core.UserToken
{
    public interface IUserTokenService
    {
        Task<UserTokenModel> GetByToken(string token);
        Task<long> Create(UserTokenModel token);
        Task DeleteByToken(string token);
    }
}
