using System.Collections.Generic;
using System.Threading.Tasks;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Contract.Domain.Student;

namespace VelvetechTZ.Core.Group
{
    public interface IGroupService
    {
        Task<long> Create(GroupContract group);
        Task Update(GroupContract group);
        Task Delete(long id);
        Task AddStudent(GroupContract group, StudentContract student);
        Task RemoveStudent(GroupContract group, StudentContract student);
        Task<List<GroupContract>> GetFiltered(GroupContract? filter);
    }
}
