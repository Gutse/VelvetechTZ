using System.Collections.Generic;
using VelvetechTZ.Domain.BaseModel;
using VelvetechTZ.Domain.Enums;
using VelvetechTZ.Domain.Group;

namespace VelvetechTZ.Domain.Student
{
    public class StudentModel: IBaseModel
    {
        public long Id { get; set; }
        public Gender Gender { get; set; }
        public string? Family { get; set; }
        public string? Name { get; set; }
        public string? SureName { get; set; }
        public string? StudentId { get; set; }
        public List<GroupModel> Groups { get; set; } = new List<GroupModel>();
    }
}
