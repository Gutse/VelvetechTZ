using System;
using System.Threading.Tasks;

namespace VelvetechTZ.Core.Authentication
{
    public interface IAuthenticationService
    {
        Task<(string Token, DateTime ExpirationTime)> SignIn(long userIdentityId, string password);
        Task<long> SignUp(string name, string email, string password);
        Task SignOut(string token);
        Task SignOutAll(string token);
    }
}