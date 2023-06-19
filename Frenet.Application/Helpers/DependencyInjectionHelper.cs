using Frenet.Application.Repositories;
using Frenet.Application.Repositories.Interfaces;
using Frenet.Application.Services;
using Frenet.Application.Services.Interfaces;

namespace Frenet.Application.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InitializeContainer(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddScoped<IShippingService, ShippingService>();
            services.AddScoped<IQuoteHistoryRepository, QuoteHistoryRepository>();
        }
    }
}