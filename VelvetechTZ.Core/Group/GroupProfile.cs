using System.Linq;
using AutoMapper;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.DAL.Models.Group;

namespace VelvetechTZ.Core.Group
{
    public class GroupProfile: Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupModel, GroupContract>()
                .ForMember(p => p.Students, opt => opt.MapFrom(m => m.Students.Select(s => s.Student))).PreserveReferences();

            CreateMap<GroupContract, GroupModel>().PreserveReferences();

            CreateMap<GroupCreateRequest, GroupContract>().ReverseMap();
            CreateMap<GroupUpdateRequest, GroupContract>().ReverseMap();
        }
    }
}
