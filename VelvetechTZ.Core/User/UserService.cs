using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VelvetechTZ.DAL.Models.User;

namespace VelvetechTZ.Core.User
{
    public class UserService : IUserService
    {
        // in real app I will user IUserRepo
        private readonly Dictionary<string, UserModel> users = new Dictionary<string, UserModel>();
        private long lastId;

        public Task<UserModel> Get(long userId)
        {
            var user = users.FirstOrDefault(u => u.Value.Id == userId);
            return Task.FromResult(user.Value);
        }

        public Task<UserModel?> GetByEmail(string email)
        {
            users.TryGetValue(email.Trim().ToLowerInvariant(), out var user);
            return Task.FromResult(user);
        }

        public Task<long> Create(UserModel user)
        {
            // todo not thread safe and validation
            lastId++;
            users.Add(user.Email ?? string.Empty, user);
            return Task.FromResult(lastId);
        }
    }
}
