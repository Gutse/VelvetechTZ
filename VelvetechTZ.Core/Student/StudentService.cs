using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VelvetechTZ.Core.Group;
using VelvetechTZ.DAL.Repository;
using VelvetechTZ.Domain.Student;

namespace VelvetechTZ.Core.Student
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<StudentModel> studentRepository;
        private readonly IMapper mapper;

        public StudentService(IRepository<StudentModel> studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public async Task<long> Create(StudentDto student)
        {
            var model = mapper.Map<StudentModel>(student);
            return await studentRepository.Insert(model);
        }

        public async Task Update(StudentDto student)
        {
            var model = mapper.Map<StudentModel>(student);
            await studentRepository.Update(model);
        }

        public async Task Delete(StudentDto student)
        {
            await studentRepository.DeleteById(student.Id);
        }

        public Task AddToGroup(StudentDto student, GroupDto @group)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<StudentDto>> GetFiltered(StudentDto filter)
        {
            throw new System.NotImplementedException();
        }
    }
}