using AutoMapper;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Contract.Domain.Student;

namespace VelvetechTZ.Core.StudentGroup
{
    public class StudentGroupProfile: Profile
    {
        public StudentGroupProfile()
        {
             // CreateMap<DAL.Models.StudentGroupRelation.StudentGroup, StudentContract>()
             //     .ForMember(m => m.StudentId, z => z.MapFrom(g => g.StudentId))
             //     .ForMember(m => m.Name, z => z.MapFrom(g => g.Student!.Name))
             //     .ForMember(m => m.Family, z => z.MapFrom(g => g.Student!.Family))
             //     .ForMember(m => m.Gender, z => z.MapFrom(g => g.Student!.Gender))
             //     .ForMember(m => m.SureName, z => z.MapFrom(g => g.Student!.SureName))
             //     .ForMember(m => m.Id, z => z.MapFrom(g => g.Student!.Id));
             //
             // CreateMap<DAL.Models.StudentGroupRelation.StudentGroup, GroupContract>()
             //     .ForMember(m => m.Name, z => z.MapFrom(g => g.Group!.Name))
             //     .ForMember(m => m.Id, z => z.MapFrom(g => g.GroupId));
        }
    }
}
