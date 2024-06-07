using EcommerceWeb.Mvc.Services.Authenticaions;
using EcommerceWeb.Mvc.Services.Carts;
using EcommerceWeb.Mvc.Services.Categories;
using EcommerceWeb.Mvc.Services.Common;
using EcommerceWeb.Mvc.Services.Products;
using EcommerceWeb.Mvc.Services.Reviews;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace EcommerceWeb.Mvc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication();
            services.AddAuthorization();
			services.AddDistributedMemoryCache();

			services.AddSession(options =>
			{
				options.Cookie.Name = ".MySession";
				options.IdleTimeout = TimeSpan.FromMinutes(30);
			});
			return services;
        }

        public static IServiceCollection AddApiClientConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
			var baseUrl = configuration.GetSection("HttpClientConfig:BaseUrl").Value ?? throw new ArgumentException("Not found API");
            var configureClient = new Action<IServiceProvider, HttpClient>((provider, client) =>
            {
                var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var httpContext = httpContextAccessor.HttpContext;
                var accessToken = httpContext?.Items["access_token"] as string ?? "";
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            });

            services.AddHttpClient<IProductServices, ProductService>(configureClient);
			services.AddHttpClient<ICategoryServices, CategoryServices>(configureClient);
            services.AddHttpClient<IReviewServices, ReviewServices>(configureClient);

            services.AddHttpClient<IAuthenticationServices, AuthenticationServices>(configureClient);

			services.AddHttpClient<ICartServices, CartServices>(configureClient);
			
			return services;
        }
    }
}
