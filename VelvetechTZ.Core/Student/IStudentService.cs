using System.Collections.Generic;
using System.Threading.Tasks;
using VelvetechTZ.Core.Group;

namespace VelvetechTZ.Core.Student
{
    public interface IStudentService
    {
        Task<long> Create(StudentDto student);
        Task Update(StudentDto student);
        Task Delete(StudentDto student);
        Task AddToGroup(StudentDto student, GroupDto group);
        Task<List<StudentDto>> GetFiltered(StudentDto filter);
    }
}
