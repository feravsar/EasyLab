using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using EasyLab.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EasyLab.Core.Entities;
using System.IO;
using Microsoft.OpenApi.Models;
using AutoMapper;
using EasyLab.WebApi.Presenters;
using EasyLab.Core.Module;
using EasyLab.Infrastructure.Module;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EasyLab.Infrastructure.Auth;
using System.Text;
using EasyLab.WebApi.Models.Settings;
using EasyLab.Infrastructure.Helpers;

namespace EasyLab.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Default"), s => s.MigrationsAssembly("EasyLab.Infrastructure")));

            // TODO: Seperate jwt config section to a new file.
            // Register the ConfigurationBuilder instance of AuthSettings
            IConfigurationSection authSettings = Configuration.GetSection(nameof(AuthSettings));
            services.Configure<AuthSettings>(authSettings);

            //
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authSettings[nameof(AuthSettings.SecretKey)]));

            // jwt wire up
            // Get options from app settings
            IConfigurationSection jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;

                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });

            // add identity
            IdentityBuilder identityBuilder = services.AddIdentityCore<User>(options =>
            {
                //Configure identity options
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
            });

            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole<Guid>), identityBuilder.Services);

            identityBuilder
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();



            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            services.AddControllers();


            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyLab Api", Version = "v1" });


                   var xmlFile = "EasyLab.Core.xml";
                   var xmlFile2 = "EasyLab.WebApi.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   var xmlPath2 = Path.Combine(AppContext.BaseDirectory, xmlFile2);

                   c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                   {
                       In = ParameterLocation.Header,
                       Description = "Please insert JWT with Bearer into field",
                       Name = "Authorization",
                       Type = SecuritySchemeType.ApiKey
                   });
                   c.AddSecurityRequirement(
                       new OpenApiSecurityRequirement()
                       {
                           {
                               new OpenApiSecurityScheme
                               {
                                   Reference = new OpenApiReference
                                   {
                                       Type = ReferenceType.SecurityScheme,Id = "Bearer"
                                    },
                                    Scheme = "oauth2",
                                    Name = "Bearer",
                                    In = ParameterLocation.Header
                                },
                                new List<string>()
                            }
                        }
                    );


                   //... and tell Swagger to use those XML comments.
                   //c.IncludeXmlComments(xmlPath);
                   //c.IncludeXmlComments(xmlPath2);
                   //c.OperationFilter<FormatXmlCommentProperties>();
               });


            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<BasePresenter>();
            services.AddCoreModule();
            services.AddInfrastructureModule();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyLab Api V1");
            });




            app.UseRouting();
            app.UseCors("AllowAny");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller}/{action=Index}/{id?}");
             });

        }
    }
}
