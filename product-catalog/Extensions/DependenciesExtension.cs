using Microsoft.Extensions.DependencyInjection;

namespace product_catalog
{
    public static class DependenciesExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();

            return serviceCollection;
        }
    }
}