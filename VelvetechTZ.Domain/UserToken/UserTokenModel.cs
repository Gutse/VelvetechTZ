using System;

namespace VelvetechTZ.Domain.UserToken
{
    public class UserTokenModel: BaseModel.BaseModel
    {
        public long UserIdentityId { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
