namespace VelvetechTZ.Core.Password
{
    public interface IPasswordService
    {
        (string hash, string salt) GetNewPassword(string? input);

        bool VerifyHashedPassword(string? hashedPassword, string? salt, string? providedPassword);
    }
}
