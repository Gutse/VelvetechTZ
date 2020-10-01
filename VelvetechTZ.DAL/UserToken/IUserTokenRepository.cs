using System;
using System.Threading.Tasks;
using VelvetechTZ.Domain.UserToken;

namespace VelvetechTZ.DAL.UserToken
{
    public interface IUserTokenRepository
    {
        Task<long> Insert(long userIdentityId, string? token, DateTime? expiration);
        Task Delete(string? token);
        Task<UserTokenModel> GetByToken(string? token);
    }
}
