using System.Reflection;
using Demeter.Application.Mappings;
using Demeter.Domain.FoodDomain;

namespace Demeter.Web.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        { 
            services.AddAutoMapper(Assembly.GetAssembly(typeof(FoodMappings)));

            return services;
        }
    }
}
