
using EasyLab.Core.Interfaces.Gateways.Repositories;
using EasyLab.Core.Interfaces.Services;
using EasyLab.Infrastructure.Auth;
using EasyLab.Infrastructure.Data.Repositories;
using EasyLab.Infrastructure.Interfaces;
using EasyLab.Infrastructure.Project;
using Microsoft.Extensions.DependencyInjection;
namespace EasyLab.Infrastructure.Module
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            #region Repositories - Alphabetic order

            services.AddTransient<IAssignmentRepository, AssignmentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseUsersRepository, CourseUsersRepository>();
            services.AddTransient<IStudentAssignmentsRepository, StudentAssignmentsRepository>();

            #endregion
            
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
            services.AddSingleton<ITokenFactory, TokenFactory>();
            services.AddSingleton<IJwtTokenValidator, JwtTokenValidator>();
            services.AddSingleton<IVerificationCodeFactory, VerificationCodeFactory>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IProjectFactory, ProjectFactory>();
            return services;
        }
    }

}
