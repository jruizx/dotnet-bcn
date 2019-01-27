using Microsoft.AspNetCore.Builder;

namespace product_catalog
{
    public static class PrometheusMetricsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCollectPrometheusMetrics(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PrometheusMetricsMiddleware>();
        }
    }
}