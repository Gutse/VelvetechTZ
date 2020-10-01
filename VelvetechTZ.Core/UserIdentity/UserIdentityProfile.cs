using AutoMapper;

namespace VelvetechTZ.Core.UserIdentity
{
    public class UserIdentityProfile: Profile
    {
        public UserIdentityProfile()
        {
            CreateMap<UserIdentityResponseContract, UserIdentityContract>().ReverseMap();
            CreateMap<UserIdentityContract, UserIdentityEntity>().ReverseMap();
        }
    }
}
