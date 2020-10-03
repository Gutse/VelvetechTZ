using System.Collections.Generic;
using System.Threading.Tasks;
using VelvetechTZ.Contract.Domain.Group;

namespace VelvetechTZ.Core.Group
{
    public interface IGroupService
    {
        Task<long> Create(GroupContract group);
        Task Update(GroupContract group);
        Task Delete(long groupId);
        Task AddStudent(long groupId, long studentId);
        Task RemoveStudent(long groupId, long studentId);
        Task<List<GroupContract>> GetFiltered(GroupContract? filter);
    }
}
