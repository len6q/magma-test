using MagmaAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace MagmaAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(
            this IServiceCollection services)
        {
            services.AddSingleton<DataController>();
            services.AddSingleton(Serializer.Deserialize());
            return services;
        }
    }
}
