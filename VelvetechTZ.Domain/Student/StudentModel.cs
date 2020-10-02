using System.Collections.Generic;
using VelvetechTZ.Domain.EFRelated;
using VelvetechTZ.Domain.Enums;
using VelvetechTZ.Domain.Group;

namespace VelvetechTZ.Domain.Student
{
    public class StudentModel: BaseModel.BaseModel
    {
        public virtual Gender Gender { get; set; }
        public virtual string? Family { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? SureName { get; set; }
        public virtual string? StudentId { get; set; }
        public virtual List<StudentGroup>? Groups { get; set; }
    }
}
