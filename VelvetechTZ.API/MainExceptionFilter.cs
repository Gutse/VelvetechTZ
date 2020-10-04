using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VelvetechTZ.Contract.Errors;

namespace VelvetechTZ.API
{
    public class MainExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            switch (context.Exception)
            {
                case ServiceException exception:
                    context.Result = new ObjectResult(exception.Error) {StatusCode = 400};
                    context.ExceptionHandled = true;
                    break;

                case ValidationException exception:
                    context.Result = new ObjectResult(new ServiceError
                    {
                        Code = AppErrors.ValidationError.Code,
                        Description = AppErrors.ValidationError.Description,
                        Meta = new ValidationError {Errors = exception.Errors.ToList()}
                    }) {StatusCode = 400};

                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}