using AutoMapper;
using VelvetechTZ.Domain.Group;

namespace VelvetechTZ.Core.Group
{
    public class GroupProfile: Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupModel, GroupDto>().ReverseMap();
        }
    }
}
