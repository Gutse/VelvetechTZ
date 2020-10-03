using VelvetechTZ.Contract.Enums;

namespace VelvetechTZ.Contract.Domain.Student
{
    public class StudentCreateRequest
    {
        public virtual Gender Gender { get; set; }
        public virtual string? Family { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? SureName { get; set; }
        public virtual string? StudentId { get; set; }
    }
}