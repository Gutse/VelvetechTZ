using FluentValidation;
using VelvetechTZ.Contract.Domain.Group;

namespace VelvetechTZ.Core.Group
{
    public class GroupContractValidator : AbstractValidator<GroupContract>
    {
        public GroupContractValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(25);
        }
    }
}
