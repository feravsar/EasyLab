using EasyLab.Core.Interfaces.UseCases.Course;
using EasyLab.Core.Interfaces.UseCases.Teacher;
using EasyLab.Core.Interfaces.UseCases.User;
using EasyLab.Core.UseCases.Course;
using EasyLab.Core.UseCases.Teacher;
using EasyLab.Core.UseCases.User;
using Microsoft.Extensions.DependencyInjection;
namespace EasyLab.Core.Module
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            services.AddTransient<IAddCourseHandler, AddCourseHandler>();
            services.AddTransient<IGetAuthoredCoursesHandler,GetAuthoredCoursesHandler>();
            services.AddTransient<IRegisterUserHandler, RegisterUserHandler>();
            services.AddTransient<IUserLoginHandler, UserLoginHandler>();
            services.AddTransient<IExchangeRefreshTokenHandler, ExchangeRefreshTokenHandler>();
            return services;
        }
    }

}
