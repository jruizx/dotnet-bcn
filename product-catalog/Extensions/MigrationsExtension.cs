using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace product_catalog
{
    public static class MigrationsExtension
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ProductCatalogContext>())
                {
                    context.Database.Migrate();
                }
            }

            return app;
        }
    }
}