using System.Collections.Generic;
using VelvetechTZ.Core.Group;
using VelvetechTZ.Domain.Enums;

namespace VelvetechTZ.Core.Student
{
    public class StudentDto
    {
        public long Id { get; set; }
        public Gender Gender { get; set; }
        public string? Family { get; set; }
        public string? Name { get; set; }
        public string? SureName { get; set; }
        public string? StudentId { get; set; }
        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
    }
}
