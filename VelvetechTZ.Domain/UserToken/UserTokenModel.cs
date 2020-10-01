using System;
using VelvetechTZ.Domain.BaseModel;

namespace VelvetechTZ.Domain.UserToken
{
    public class UserTokenModel: IBaseModel
    {
        public long Id { get; set; }
        public long UserIdentityId { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
