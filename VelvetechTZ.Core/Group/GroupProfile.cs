using AutoMapper;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.DAL.Models.Group;

namespace VelvetechTZ.Core.Group
{
    public class GroupProfile: Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupModel, GroupContract>().ReverseMap();
            CreateMap<GroupCreateRequest, GroupContract>().ReverseMap();
            CreateMap<GroupUpdateRequest, GroupContract>().ReverseMap();
        }
    }
}
