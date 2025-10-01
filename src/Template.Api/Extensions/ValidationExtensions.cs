using Template.Core.Models.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Template.Api.Extensions;

public static class ValidationExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddControllers(o => o.Filters.Add(typeof(ValidationFilter)))
            .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);

        services.AddFluentValidationAutoValidation();

        services.AddFluentValidationClientsideAdapters();

        // TODO: Register all validators in assembly
        // services.AddValidatorsFromAssemblyContaining<CadastroClienteInputModelValidator>();

        return services;
    }

    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(
                    new DefaultResponseViewModel(
                        context
                            .ModelState.SelectMany(ms => ms.Value?.Errors ?? [])
                            .Select(e => e.ErrorMessage)
                    )
                );
            }
        }
    }
}
