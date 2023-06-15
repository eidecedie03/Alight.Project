using Application.Common.Helpers;
using Application.Common.Validators;
using Application.ServiceContracts;
using Application.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Extensions
{
    public static class BusinessServiceCollectionExtension
    {
        public static void RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            SetupValidators(services);

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IValidationHelper, ValidationHelper>();
        }

        private static void SetupValidators(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
        }
    }
}
