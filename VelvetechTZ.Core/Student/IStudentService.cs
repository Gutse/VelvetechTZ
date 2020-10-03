using System.Collections.Generic;
using System.Threading.Tasks;
using VelvetechTZ.Contract.Domain.Student;

namespace VelvetechTZ.Core.Student
{
    public interface IStudentService
    {
        Task<long> Create(StudentContract student);
        Task Update(StudentContract student);
        Task Delete(long id);
        Task<List<StudentContract>> GetFiltered(StudentContract? filter);
    }
}
