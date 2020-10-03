namespace VelvetechTZ.Contract.Domain.User
{
    public class UserContract
    {
        public long UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
    }
}
