using AutoMapper;
using VelvetechTZ.Domain.Student;

namespace VelvetechTZ.Core.Student
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentModel, StudentDto>().ReverseMap();
        }
    }
}