using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Order.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddAplicationService(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistiration).Assembly));
        }
    }
}
