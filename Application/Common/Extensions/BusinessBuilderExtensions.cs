using Application.Common.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Application.Common.Extensions
{
    public static class BusinessBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
        }
    }
}
