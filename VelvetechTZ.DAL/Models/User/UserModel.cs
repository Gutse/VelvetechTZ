namespace VelvetechTZ.DAL.Models.User
{
    public class UserModel: BaseModel.BaseModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
    }
}
