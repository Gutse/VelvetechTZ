using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task<StudentContract> Get(long id)
        {
            var entity = await studentRepository.GetById(id);
            return mapper.Map<StudentContract>(entity);
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

        public async Task Delete(long id)
        {
            await studentRepository.DeleteById(id);
        }

        public async Task<List<StudentContract>> GetFiltered(StudentContract? filter)
        {
            var models = await studentRepository.GetFiltered(model =>
            {
                var result = true;

                if (!string.IsNullOrWhiteSpace(filter?.Name))
                    result = result && (model.Name?.Contains(filter.Name) ?? false);

                if (!string.IsNullOrWhiteSpace(filter?.Family))
                    result = result && (model.Name?.Contains(filter.Family) ?? false);

                if (!string.IsNullOrWhiteSpace(filter?.SureName))
                    result = result && (model.Name?.Contains(filter.SureName) ?? false);

                if (filter?.Gender != null)
                    result = result && model.Gender == (int)filter.Gender;

                if (!string.IsNullOrWhiteSpace(filter?.Family))
                    result = result && (model.Name?.Contains(filter.Family) ?? false);

                return result;
            });

            return mapper.Map<List<StudentContract>>(models);
        }
    }
}