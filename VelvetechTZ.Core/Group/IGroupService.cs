using System.Collections.Generic;
using System.Threading.Tasks;
using VelvetechTZ.Core.Student;

namespace VelvetechTZ.Core.Group
{
    public interface IGroupService
    {
        Task<long> Create(GroupDto group);
        Task Update(GroupDto group);
        Task Delete(GroupDto group);
        Task AddStudent(GroupDto group, StudentDto student);
        Task<List<GroupDto>> GetFiltered(GroupDto filter);
    }
}
