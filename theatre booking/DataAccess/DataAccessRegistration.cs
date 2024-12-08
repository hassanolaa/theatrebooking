using theatre_booking.DataAccess.contracts;
using theatre_booking.DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace theatre_booking.DataAccess
{
    public static class DataAccessRegistration
    {
        public static IServiceCollection RegisterDataAccess(this IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>();
            services.AddScoped<UnitOfWorkRepo>();
            services.AddScoped<IUnitofWork, UnitOfWorkRepo>();

            // Register repositories
            services.AddScoped<IEventRepo, EventRepo>();
            services.AddScoped<IThreatreRepo, ThreatreRepo>();
            services.AddScoped<ISeatRepo, SeatRepo>();
            services.AddScoped<IUserRepo, UserRepo>();


            return services;
        }
    }
}
