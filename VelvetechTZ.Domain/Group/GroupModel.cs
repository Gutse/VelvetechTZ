using System.Collections.Generic;
using VelvetechTZ.Domain.BaseModel;
using VelvetechTZ.Domain.Student;

namespace VelvetechTZ.Domain.Group
{
    public class GroupModel: IBaseModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
