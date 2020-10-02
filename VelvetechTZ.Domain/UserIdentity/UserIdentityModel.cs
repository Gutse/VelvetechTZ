namespace VelvetechTZ.Domain.UserIdentity
{
    public class UserIdentityModel: BaseModel.BaseModel
    {
        public long UserId { get; set; }
        public string? Identity { get; set; }
        public string? Salt { get; set; }
    }
}
