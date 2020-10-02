using VelvetechTZ.Domain.Group;
using VelvetechTZ.Domain.Student;

namespace VelvetechTZ.Domain.EFRelated
{
    public class StudentGroup
    {
        public long StudentId { get; set; }
        public StudentModel? Student { get; set; }

        public long GroupId { get; set; }
        public GroupModel? Group { get; set; }
    }
}
