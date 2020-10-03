using System.Collections.Generic;
using VelvetechTZ.DAL.Models.StudentGroupRelation;

namespace VelvetechTZ.DAL.Models.Student
{
    public class StudentModel: BaseModel.BaseModel
    {
        public virtual int Gender { get; set; }
        public virtual string? Family { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? SureName { get; set; }
        public virtual string? StudentId { get; set; }
        public virtual List<StudentGroup>? Groups { get; set; }
    }
}
