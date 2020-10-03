using VelvetechTZ.DAL.Models.Group;
using VelvetechTZ.DAL.Models.Student;

namespace VelvetechTZ.DAL.Models.StudentGroupRelation
{
    public class StudentGroup
    {
        public virtual long StudentId { get; set; }
        public virtual StudentModel? Student { get; set; }

        public virtual long GroupId { get; set; }
        public virtual GroupModel? Group { get; set; }
    }
}
