using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VelvetechTZ.Domain.UserToken;

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

        public Task<long> Insert(long userIdentityId, string? token, DateTime? expiration)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Token is empty", token);

            if (tokens.TryGetValue(token ?? string.Empty, out var storedToken))
                throw new ArgumentException("Token already exist", token);

            var newToken = new UserTokenModel { Expiration = expiration, Token = token, UserIdentityId = userIdentityId, Id = ++lastId };

            tokens.Add(token ?? string.Empty, newToken);

            return Task.FromResult(newToken.Id);
        }

        public Task Delete(string? token)
        {
            if (token == null)
#pragma warning disable CA2201 // Не порождайте исключения зарезервированных типов
                throw new NullReferenceException("token is null");
#pragma warning restore CA2201 // Не порождайте исключения зарезервированных типов

            if (tokens.ContainsKey(token))
                tokens.Remove(token);

            return Task.CompletedTask;
        }
    }
}
