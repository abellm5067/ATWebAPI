using ATWebAPI.Services;
using ATWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using EFRepository.Services;
using AutoMapper;
using EFRepository.Services.Interace;
using ATWebAPI.Facade;
using ATWebAPI.Facade.Interface;

namespace ATWebAPI
{
    public static class ServiceInjections
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            serviceCollection.AddSingleton(mapper);
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            
            serviceCollection.AddAuthorization();
            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IUserBusiness, UserBusiness>();
            serviceCollection.AddControllers();
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AT API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Add a security requirement
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
            });

            serviceCollection.AddEndpointsApiExplorer();
            AppConfig.LoadConfiguration(configuration);
           
        }
    }
}
