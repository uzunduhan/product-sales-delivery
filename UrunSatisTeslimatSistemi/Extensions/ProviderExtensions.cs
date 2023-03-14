using Microsoft.Extensions.DependencyInjection;

namespace UrunSatisTeslimatSistemi.Extensions
{
    public static class ProviderExtensions
    {

        public static T GetService<T>(T service)
        {
            return ServiceProvider.GetService<T>();
        }

        public static T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
        private static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection CreateProvider(this IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
