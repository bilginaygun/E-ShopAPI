using E_ShopAPI.Apı.Validation.FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_ShopAPI.Apı.Aspects
{
    public class ValidationFilter : Attribute, IAsyncActionFilter
    {
        private Type _validatorType;

        public ValidationFilter(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ValidationHelper.Validate(_validatorType, context.ActionArguments.Values.ToArray());
            var executedContext = await next();
        }
    }
}
