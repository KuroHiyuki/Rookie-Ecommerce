using EcommerceWeb.Mvc.Services.Categories;
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

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                        .AddCookie("Cookies")
                        .AddOpenIdConnect("oidc", options =>
                        {
                            options.Authority = "https://localhost:7280"; // IdentityServer Url

                            options.ClientId = "EcommerceWeb.Mvc";
                            options.ClientSecret = "This is how it strong to be pass every challenger";
                            options.ResponseType = "code";
                            options.SaveTokens = true;

                            options.Scope.Add("openid");
                            options.Scope.Add("profile");
                            options.Scope.Add("EcommerceWeb.WebApi");
                            options.Scope.Add("offline_access");

                            options.GetClaimsFromUserInfoEndpoint = true;
                            options.ClaimActions.MapJsonKey(ClaimTypes.Role, "role");
                            options.TokenValidationParameters.NameClaimType = "name";
                            options.TokenValidationParameters.RoleClaimType = "role";
                        });
            return services;
        }

        public static IServiceCollection AddApiClientConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
			var baseUrl = configuration.GetSection("HttpClientConfig:BaseUrl").Value;

			var configureClient = new Action<IServiceProvider, HttpClient>(async (provider, client) =>
            {
                var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var accessToken = await httpContextAccessor?.HttpContext?.GetTokenAsync("access_token") ?? "";
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            });

            services.AddHttpClient<IProductServices, ProductService>(configureClient);
			services.AddHttpClient<ICategoryServices, CategoryServices>(configureClient);
            services.AddHttpClient<IReviewServices, ReviewServices>(configureClient);
            //services.AddHttpClient<ICategoriesApiClient, CategoriesApiClient>(configureClient);
            //services.AddHttpClient<ICartApiClient, CartApiClient>(configureClient);
            //services.AddHttpClient<IReviewsApiClient, ReviewsApiClient>(configureClient);
            //services.AddHttpClient<IOrdersApiClient, OrdersApiClient>(configureClient);
            //services.AddHttpClient<IAccountApiClient, AccountApiClient>(configureClient);

            return services;
        }
    }
}
