using System.Collections.Generic;
using VelvetechTZ.Core.Student;

namespace VelvetechTZ.Core.Group
{
    public class GroupDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
