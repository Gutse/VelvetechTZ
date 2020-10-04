using FluentValidation.Results;
using System.Collections.Generic;

namespace VelvetechTZ.Contract.Errors
{
    public class ValidationError
    {
        public List<ValidationFailure>? Errors { get; set; }
    }
}
