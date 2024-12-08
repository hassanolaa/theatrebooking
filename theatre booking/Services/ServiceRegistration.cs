using Microsoft.Extensions.DependencyInjection;
using theatre_booking.Services.Contracts;
using theatre_booking.Services.ServicesRepos;

namespace theatre_booking.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IEventDto, EventDtoServices>();
            services.AddScoped<ITheatreDto, TheatreDtoServices>();
            services.AddScoped<ISeatDto, SeatDtoServices>();
            services.AddScoped<IUserDto, UserDtoServices>();

            return services;
        }
    }
}
