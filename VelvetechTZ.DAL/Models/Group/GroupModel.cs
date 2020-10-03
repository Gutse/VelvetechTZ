using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VelvetechTZ.DAL.Models.StudentGroupRelation;

namespace VelvetechTZ.DAL.Models.Group
{
    public class GroupModel: BaseModel.BaseModel
    {
        [Required]
        [StringLength(25)]
        [MinLength(1)]
        public virtual string? Name { get; set; }

        public virtual List<StudentGroup>? Students { get; set; }
    }
}
