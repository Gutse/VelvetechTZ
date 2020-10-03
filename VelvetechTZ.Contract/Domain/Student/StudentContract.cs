using System.Collections.Generic;
using VelvetechTZ.Contract.Enums;

namespace VelvetechTZ.Contract.Domain.Student
{
    public class StudentContract
    {
        public virtual long Id { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual string? Family { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? SureName { get; set; }
        public virtual string? StudentId { get; set; }
        public virtual List<StudentContract>? Groups { get; set; }
    }
}
