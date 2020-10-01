using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace VelvetechTZ.Core.Authentication
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
        {
                RuleFor(x => x).Must(x => Regex.IsMatch(x, @"^(?=.*\p{Ll})(?=.*\p{Lu})(?=.*\d)(?=.*[^\d\p{L}]).{8,15}$", RegexOptions.Compiled | RegexOptions.CultureInvariant , TimeSpan.FromSeconds(1)))
                .WithServiceError(AppErrors.WeakPassword);
        }
    }
}
