using EF;
using EF.Repositories;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Api.Extensions
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<ISecurityProvider, SecurityProvider>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IListRepository, ListRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }

        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ProjectContext>(options =>
            {
                var connectionString = config.GetConnectionString("MainDbContext");
                options.UseNpgsql(connectionString);
            });
            //services.AddDbContext<ProjectContext>(options => options.UseInMemoryDatabase("Project"));
            return services;
        }

        public static IServiceCollection AddAuthenticationWithJwtBearer(this IServiceCollection services)
        {
            var securityProvider = services.BuildServiceProvider().GetService<ISecurityProvider>() as ISecurityProvider;

            if (securityProvider == null)
            {
                throw new ArgumentNullException(nameof(securityProvider));
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityProvider.SecurityKey));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = securityProvider.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = securityProvider.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = symmetricSecurityKey,
                        ValidateIssuerSigningKey = true,
                    };
                });
            return services;

        }

        public static IServiceCollection AddSwaggerGenWithOptions(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new string[] { }
                    }
                });
            });
            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors();

            return services;
        }
    }
}