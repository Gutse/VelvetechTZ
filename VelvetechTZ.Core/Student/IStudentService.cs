using System.Collections.Generic;
using System.Threading.Tasks;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Contract.Domain.Student;

namespace VelvetechTZ.Core.Student
{
    public interface IStudentService
    {
        Task<long> Create(StudentContract student);
        Task Update(StudentContract student);
        Task Delete(StudentContract student);
        Task AddToGroup(StudentContract student, GroupContract group);
        Task<List<StudentContract>> GetFiltered(StudentContract filter);
    }
}
