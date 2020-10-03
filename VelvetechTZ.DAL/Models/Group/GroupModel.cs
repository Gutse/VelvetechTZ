using System.Collections.Generic;
using VelvetechTZ.DAL.Models.StudentGroupRelation;

namespace VelvetechTZ.DAL.Models.Group
{
    public class GroupModel: BaseModel.BaseModel
    {
        public virtual string? Name { get; set; }
        public virtual List<StudentGroup>? Students { get; set; }
    }
}
