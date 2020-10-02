using VelvetechTZ.Domain.BaseModel;

namespace VelvetechTZ.Domain.UserIdentity
{
    public class UserIdentityModel: IBaseModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? Identity { get; set; }
        public string? Salt { get; set; }
    }
}
