using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VelvetechTZ.DAL.Models.StudentGroupRelation;

namespace VelvetechTZ.DAL.Models.Student
{
    public class StudentModel: BaseModel.BaseModel
    {
        public virtual int Gender { get; set; }

        [StringLength(40)]
        [Required]
        [MinLength(1)]
        public virtual string? Family { get; set; }

        [StringLength(40)]
        [Required]
        [MinLength(1)]
        public virtual string? Name { get; set; }

        [StringLength(60)]
        [Required]
        [MinLength(1)]
        public virtual string? SureName { get; set; }

        [StringLength(16)]
        [MinLength(6)]
        public virtual string? StudentId { get; set; }

        public virtual List<StudentGroup>? Groups { get; set; }
    }
}
