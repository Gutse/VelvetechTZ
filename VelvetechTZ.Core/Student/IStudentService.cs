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
    }
}
