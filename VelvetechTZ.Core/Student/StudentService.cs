using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Contract.Domain.Student;
using VelvetechTZ.DAL.Models.Student;
using VelvetechTZ.DAL.Repository;

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

        public async Task<long> Create(StudentContract student)
        {
            var model = mapper.Map<StudentModel>(student);
            return await studentRepository.Insert(model);
        }

        public async Task Update(StudentContract student)
        {
            var model = mapper.Map<StudentModel>(student);
            await studentRepository.Update(model);
        }

        public async Task Delete(StudentContract student)
        {
            await studentRepository.DeleteById(student.Id);
        }

        public Task AddToGroup(StudentContract student, GroupContract @group)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<StudentContract>> GetFiltered(StudentContract filter)
        {
            throw new System.NotImplementedException();
        }
    }
}