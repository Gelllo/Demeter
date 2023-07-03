using System.Reflection;
using Demeter.Application;
using Demeter.Infrastracture;

namespace Demeter.Web.Configuration
{
    public static class HandlersConfiguration
    {
        public static IServiceCollection ConfigureHandlers(this IServiceCollection services)
        {
            services.Scan(selector =>
            {
                selector.FromAssemblyDependencies(Assembly.GetAssembly(typeof(DataContext)))
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(IQueryHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            services.Scan(selector =>
            {
                selector.FromAssemblyDependencies(Assembly.GetAssembly(typeof(DataContext)))
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(Demeter.Application.ICommandHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            return services;
        }
    }
}
