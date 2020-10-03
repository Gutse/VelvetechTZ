using System.Linq;
using AutoMapper;
using VelvetechTZ.Contract.Domain.Student;
using VelvetechTZ.DAL.Models.Student;

namespace VelvetechTZ.Core.Student
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
//            CreateMap<StudentModel, StudentContract>().ReverseMap();

            CreateMap<StudentModel, StudentContract>()
                .ForMember(p => p.Groups, opt => opt.MapFrom(m => m.Groups.Select(s => s.Group))).PreserveReferences();

            CreateMap<StudentContract, StudentModel>().PreserveReferences();

            CreateMap<StudentCreateRequest, StudentContract>().ReverseMap();
            CreateMap<StudentUpdateRequest, StudentContract>().ReverseMap();
        }
    }
}