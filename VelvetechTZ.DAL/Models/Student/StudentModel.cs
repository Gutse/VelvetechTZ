using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VelvetechTZ.DAL.Models.StudentGroupRelation;

namespace VelvetechTZ.DAL.Models.Student
{
    public class StudentModel: BaseModel.BaseModel
    {
        public virtual int? Gender { get; set; }

        [Required]
        [MinLength(1)]
        [StringLength(40)]
        public virtual string? Family { get; set; }

        [Required]
        [MinLength(1)]
        [StringLength(40)]
        public virtual string? Name { get; set; }

        [Required]
        [MinLength(1)]
        [StringLength(60)]
        public virtual string? SureName { get; set; }

        [MinLength(6)]
        [StringLength(16)]
        public virtual string? StudentId { get; set; }

        public virtual List<StudentGroup>? Groups { get; set; }
    }
}
