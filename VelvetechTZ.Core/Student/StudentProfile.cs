using AutoMapper;
using VelvetechTZ.Contract.Domain.Student;
using VelvetechTZ.DAL.Models.Student;

namespace VelvetechTZ.Core.Student
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentModel, StudentContract>().ReverseMap();
            CreateMap<StudentCreateRequest, StudentContract>().ReverseMap();
            CreateMap<StudentUpdateRequest, StudentContract>().ReverseMap();
        }
    }
}