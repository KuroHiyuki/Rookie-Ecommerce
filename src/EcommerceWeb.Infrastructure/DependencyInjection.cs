using EcommerceWeb.Application.Authentication.Common.Interfaces;
using EcommerceWeb.Application.Common.Services;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Authentication;
using EcommerceWeb.Infrastructure.Authentication.Repository;
using EcommerceWeb.Infrastructure.Common.Service;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EcommerceWeb.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
         this IServiceCollection services,
         ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistance();

            //services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services)
        {
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer("Data Source=.;Initial Catalog=EcommerceDb;Integrated Security=True;TrustServerCertificate=true"));

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IPasswordHasher<Customer>, PasswordHasher<Customer>>();
            //services.AddScoped<IMenuRepository, MenuRepository>();
            //services.AddScoped<IDinnerRepository, DinnerRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
                this IServiceCollection services,
                ConfigurationManager configuration)
        {
            var JwtSetting = new JwtSetting();
            configuration.Bind(JwtSetting.SectionName, JwtSetting);
            services.AddSingleton(Options.Create(JwtSetting));

            //services.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimProvider>();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = JwtSetting.Audience,
                    ValidIssuer = JwtSetting.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(JwtSetting.Secret!))
                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync("Unauthurized");
                    }
                };
            });
            services.AddAuthorization();
            return services;
        }
    }
}
