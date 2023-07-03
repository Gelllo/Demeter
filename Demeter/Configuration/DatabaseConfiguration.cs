using Demeter.Application;
using Demeter.Application.Repository;
using Microsoft.EntityFrameworkCore;
using Demeter.Infrastracture.Dispatchers;
using Demeter.Infrastracture;
using Demeter.Infrastracture.Repository;

namespace Demeter.Web.Configuration
{
    public static class DatabaseConfiguration
    {
        public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(x =>
                x.UseLazyLoadingProxies()
                    .UseSqlServer(builder.Configuration.GetConnectionString("DemeterConnection")));
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            return builder;
        }
    }
}
