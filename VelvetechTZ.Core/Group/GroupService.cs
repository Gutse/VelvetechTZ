using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VelvetechTZ.Core.Student;
using VelvetechTZ.DAL.Repository;
using VelvetechTZ.Domain.Group;

namespace VelvetechTZ.Core.Group
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<GroupModel> groupRepository;
        private readonly IMapper mapper;

        public GroupService(IRepository<GroupModel> groupRepository, IMapper mapper)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }

        public async Task<long> Create(GroupDto group)
        {
            var model = mapper.Map<GroupModel>(group);
            return await groupRepository.Insert(model);
        }

        public async Task Update(GroupDto group)
        {
            var model = mapper.Map<GroupModel>(group);
            await groupRepository.Update(model);
        }

        public async Task Delete(GroupDto group)
        {
            await groupRepository.DeleteById(group.Id);
        }

        public Task AddStudent(GroupDto group, StudentDto student)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<GroupDto>> GetFiltered(GroupDto filter)
        {
            throw new System.NotImplementedException();
        }
    }
}