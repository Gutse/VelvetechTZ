using AutoMapper;

namespace VelvetechTZ.Core.UserToken
{
    public class UserTokenProfile: Profile
    {
        public UserTokenProfile()
        {
            CreateMap<UserTokenContract, UserTokenModel>().ReverseMap();
        }
    }
}
