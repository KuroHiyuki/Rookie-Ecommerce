using EcommerceWeb.Presentation.Persistences;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
                //.AddAuth(configuration)
                .AddPersistance();

            //services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services)
        {
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer("Data Source=.;Initial Catalog=EcommerceDb;Integrated Security=True;TrustServerCertificate=true"));

            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IMenuRepository, MenuRepository>();
            //services.AddScoped<IDinnerRepository, DinnerRepository>();

            return services;
        }

        //public static IServiceCollection AddAuth(
        //        this IServiceCollection services,
        //        ConfigurationManager configuration)
        //{
        //    var jwtSettings = new JwtSettings();
        //    configuration.Bind(JwtSettings.SectionName, jwtSettings);

        //    services.AddSingleton(Options.Create(jwtSettings));
        //    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        //    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = jwtSettings.Issuer,
        //            ValidAudience = jwtSettings.Audience,
        //            IssuerSigningKey = new SymmetricSecurityKey(
        //                Encoding.UTF8.GetBytes(jwtSettings.Secret)),
        //        });

        //    return services;
        //}
    }
}
