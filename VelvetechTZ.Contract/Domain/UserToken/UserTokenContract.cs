using System;

namespace VelvetechTZ.Contract.Domain.UserToken
{
    public class UserTokenContract
    {
        public long UserTokenId { get; set; }
        public long UserId { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
