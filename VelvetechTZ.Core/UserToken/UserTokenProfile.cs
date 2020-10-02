using AutoMapper;
using VelvetechTZ.Domain.UserToken;

namespace VelvetechTZ.Core.UserToken
{
    public class UserTokenProfile: Profile
    {
        public UserTokenProfile()
        {
            CreateMap<UserTokenModel, UserTokenModel>().ReverseMap();
        }
    }
}
