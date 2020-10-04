using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Contract.Errors;
using VelvetechTZ.DAL.Models.Group;
using VelvetechTZ.DAL.Models.Student;
using VelvetechTZ.DAL.Repository;

namespace VelvetechTZ.Core.Group
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<GroupModel> groupRepository;
        private readonly IRepository<StudentModel> studentRepository;
        private readonly IMapper mapper;
        private readonly GroupContractValidator groupContractValidator;

        public GroupService(IRepository<GroupModel> groupRepository, IMapper mapper, GroupContractValidator groupContractValidator, IRepository<StudentModel> studentRepository)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
            this.groupContractValidator = groupContractValidator;
            this.studentRepository = studentRepository;
        }

        public async Task<GroupContract> Get(long id)
        {
            var entity = await groupRepository.GetById(id);
            return mapper.Map<GroupContract>(entity);
        }

        public async Task<long> Create(GroupContract group)
        {
            await groupContractValidator.ValidateAndThrowAsync(group);

            var model = mapper.Map<GroupModel>(group);
            return await groupRepository.Insert(model);
        }

        public async Task Update(GroupContract group)
        {
            await groupContractValidator.ValidateAndThrowAsync(group);
            var model = mapper.Map<GroupModel>(group);
            await groupRepository.Update(model);
        }

        public async Task Delete(long id)
        {
            await groupRepository.DeleteById(id);
        }

        public async Task AddStudent(long groupId, long studentId)
        {
            var group = await groupRepository.GetById(groupId);
            if (group == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            var student = await studentRepository.GetById(studentId);
            if (student == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            group.Students.Add(new DAL.Models.StudentGroupRelation.StudentGroup {GroupId = groupId, StudentId = studentId});
            await groupRepository.Update(group);
        }

        public async Task RemoveStudent(long groupId, long studentId)
        {
            var group = await groupRepository.GetById(groupId);
            if (group == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            var student = group.Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
                throw new ServiceException(AppErrors.EntityDoesNotExists);

            group.Students.Remove(student);
            await groupRepository.Update(group);
        }

        public async Task<List<GroupContract>> GetFiltered(GroupContract? filter)
        {
            var models = await groupRepository.GetFiltered(model =>
            {
                if (!string.IsNullOrWhiteSpace(filter?.Name))
                    return model.Name?.Contains(filter.Name) ?? false;

                return true;
            });

            return mapper.Map<List<GroupContract>>(models);
        }
    }
}