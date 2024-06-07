namespace EcommerceWeb.Mvc.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider provider)
        {
            return provider.GetRequiredService<T>();
        }
    }
}
