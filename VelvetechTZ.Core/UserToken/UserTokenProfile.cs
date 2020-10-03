using AutoMapper;
using VelvetechTZ.DAL.Models.UserToken;

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
