using Microsoft.AspNetCore.Builder;

namespace orders
{
    public static class PrometheusMetricsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCollectPrometheusMetrics(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PrometheusMetricsMiddleware>();
        }
    }
}