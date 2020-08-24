using EasyLab.Core.Interfaces.UseCases.User;
using EasyLab.Core.UseCases.User;
using Microsoft.Extensions.DependencyInjection;
namespace EasyLab.Core.Module
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            services.AddTransient<IRegisterUserHandler, RegisterUserHandler>();
            return services;
        }
    }

}
