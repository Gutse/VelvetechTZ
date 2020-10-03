using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VelvetechTZ.DAL.Models.UserToken;

namespace VelvetechTZ.DAL.UserToken
{
    public class UserTokenRepository : IUserTokenRepository
    {
        // for TZ just in mem storage.
        private long lastId;
        private readonly Dictionary<string, UserTokenModel> tokens = new Dictionary<string, UserTokenModel>();

        public Task<UserTokenModel> GetByToken(string? token)
        {
            if (tokens.TryGetValue(token ?? string.Empty, out var storedToken))
                return Task.FromResult(storedToken);

            // todo throw custom exception
            throw new ArgumentException("Token not exist", token);
        }

        public Task<long> Insert(long userId, string? token, DateTime? expiration)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Token is empty", token);

            if (tokens.TryGetValue(token ?? string.Empty, out var storedToken))
                throw new ArgumentException("Token already exist", token);

            var newToken = new UserTokenModel { Expiration = expiration, Token = token, Id = ++lastId };

            tokens.Add(token ?? string.Empty, newToken);

            return Task.FromResult(newToken.Id);
        }

        public Task Delete(string? token)
        {
            if (token == null)
                throw new ArgumentException("token is null");

            if (tokens.ContainsKey(token))
                tokens.Remove(token);

            return Task.CompletedTask;
        }
    }
}
