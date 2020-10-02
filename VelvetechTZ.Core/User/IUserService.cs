using System.Threading.Tasks;
using VelvetechTZ.Domain.User;

namespace VelvetechTZ.Core.User
{
    public interface IUserService
    {
        Task<UserModel> Get(long userId);
        Task<UserModel?> GetByEmail(string email);
        Task<long> Create(UserModel user);
    }
}
