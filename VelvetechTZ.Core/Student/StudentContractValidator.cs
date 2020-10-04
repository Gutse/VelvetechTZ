using FluentValidation;
using VelvetechTZ.Contract.Domain.Student;

namespace VelvetechTZ.Core.Student
{
    public class StudentContractValidator : AbstractValidator<StudentContract>
    {
        public StudentContractValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(40);
            RuleFor(e => e.Family).NotEmpty().MaximumLength(40);
            RuleFor(e => e.SureName).NotEmpty().MaximumLength(60);
            RuleFor(e => e.StudentId).MinimumLength(6).MaximumLength(60);
        }
    }
}
