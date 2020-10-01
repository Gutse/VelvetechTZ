using FluentValidation;

namespace VelvetechTZ.Core.UserIdentity
{
    public class UserIdentityContractValidator : AbstractValidator<UserIdentityContract>
    {
        public UserIdentityContractValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0);

            RuleFor(x => x.Identity)
                .NotEmpty();

            RuleFor(x => x.Salt)
                .NotEmpty()
                .MaximumLength(256);
        }
    }
}
