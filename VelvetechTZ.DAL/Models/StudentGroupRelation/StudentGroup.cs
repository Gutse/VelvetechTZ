using VelvetechTZ.DAL.Models.Group;
using VelvetechTZ.DAL.Models.Student;

namespace VelvetechTZ.DAL.Models.StudentGroupRelation
{
    public class StudentGroup
    {
        public long StudentId { get; set; }
        public StudentModel? Student { get; set; }

        public long GroupId { get; set; }
        public GroupModel? Group { get; set; }
    }
}
