using System;
using System.Threading.Tasks;
using VelvetechTZ.DAL.Models.UserToken;

namespace VelvetechTZ.DAL.UserToken
{
    public interface IUserTokenRepository
    {
        Task<long> Insert(long userId, string? token, DateTime? expiration);
        Task Delete(string? token);
        Task<UserTokenModel> GetByToken(string? token);
    }
}
