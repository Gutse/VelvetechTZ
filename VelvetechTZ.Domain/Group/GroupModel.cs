using System.Collections.Generic;
using VelvetechTZ.Domain.BaseModel;
using VelvetechTZ.Domain.Student;

namespace VelvetechTZ.Domain.Group
{
    public class GroupModel: BaseModel.BaseModel
    {
        public virtual string? Name { get; set; }
        public virtual ICollection<StudentModel>? Students { get; set; }
    }
}
