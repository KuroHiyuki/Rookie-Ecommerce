using EcommerceWeb.WebApi.Common;
using EcommerceWeb.WebApi.Common.Error;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EcommerceWeb.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();


            return services;
        }
    }
}
