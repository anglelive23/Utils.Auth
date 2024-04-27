using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Utils.Auth.Controllers;
using Utils.Auth.Entities.Helpers;
using Utils.Auth.Entities.Services;
using Utils.Core.Entities;

namespace Utils.Auth
{
    public static class AuthServiceRegisteration
    {
        public static IServiceCollection AddAuthServices<TContext>(
            this IServiceCollection services,
            IConfiguration configuration)
           where TContext : DbContext
        {
            #region Identity
            services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<TContext>();
            #endregion

            #region Identity Controller
            services.AddControllers()
                .AddApplicationPart(typeof(AuthController).Assembly);
            #endregion

            #region JWT
            services.Configure<JWT>(configuration.GetSection(nameof(JWT)));
            services.AddScoped<IAuthService, AuthService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"] ?? "OdkSeYWNl/ECZJaRsjzTqQ9rGb7jp0Ovp57idk1LeGs=")),
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion

            return services;
        }
    }
}
