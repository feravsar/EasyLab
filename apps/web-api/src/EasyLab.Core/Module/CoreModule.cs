using Microsoft.Extensions.DependencyInjection;

using EasyLab.Core.Interfaces.UseCases.Account;
using EasyLab.Core.Interfaces.UseCases.Auth;
using EasyLab.Core.Interfaces.UseCases.Student;
using EasyLab.Core.Interfaces.UseCases.Teacher;
using EasyLab.Core.UseCases.Account;
using EasyLab.Core.UseCases.Auth;
using EasyLab.Core.UseCases.Student;
using EasyLab.Core.UseCases.Teacher;

namespace EasyLab.Core.Module
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            services.AddTransient<IAddCourseHandler, AddCourseHandler>();
            services.AddTransient<ICreateAssignmentHandler, CreateAssignmentHandler>();
            services.AddTransient<IGetAuthoredCoursesHandler, GetAuthoredCoursesHandler>();
            services.AddTransient<IGetAssignmentsHandler, GetAssignmentsHandler>();
            services.AddTransient<IGetEnrolledCoursesHandler, GetEnrolledCoursesHandler>();
            services.AddTransient<IGetMembersHandler, GetMembersHandler>();
            services.AddTransient<IGetProjectsHandler, GetProjectsHandler>();
            services.AddTransient<IRegisterUserHandler, RegisterUserHandler>();
            services.AddTransient<ISearchUserHandler, SearchUserHandler>();
            services.AddTransient<IUserLoginHandler, UserLoginHandler>();
            services.AddTransient<IAddMemberHandler, AddMemberHandler>();
            services.AddTransient<IExchangeRefreshTokenHandler, ExchangeRefreshTokenHandler>();
            services.AddTransient<IStartProjectHandler, StartProjectHandler>();

            return services;
        }
    }

}
