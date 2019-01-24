using Microsoft.Extensions.DependencyInjection;

namespace orders
{
    public static class DependenciesExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddTransient<IOrderContext, OrderContext>();
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();

            return serviceCollection;
        }
    }
}