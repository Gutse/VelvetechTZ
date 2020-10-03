using System.Collections.Generic;
using VelvetechTZ.Contract.Domain.Student;

namespace VelvetechTZ.Contract.Domain.Group
{
    public class GroupContract
    {
        public virtual long Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual List<StudentContract>? Students { get; set; }
    }
}
