using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.DAL.Models.Group;
using VelvetechTZ.DAL.Repository;

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

        public async Task<GroupContract> Get(long id)
        {
            var entity = await groupRepository.GetById(id);
            return mapper.Map<GroupContract>(entity);
        }

        public async Task<long> Create(GroupContract group)
        {
            var model = mapper.Map<GroupModel>(group);
            return await groupRepository.Insert(model);
        }

        public async Task Update(GroupContract group)
        {
            var model = mapper.Map<GroupModel>(group);
            await groupRepository.Update(model);
        }

        public async Task Delete(long id)
        {
            await groupRepository.DeleteById(id);
        }

        public Task AddStudent(long groupId, long studentId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveStudent(long groupId, long studentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<GroupContract>> GetFiltered(GroupContract? filter)
        {
            throw new System.NotImplementedException();
        }
    }
}