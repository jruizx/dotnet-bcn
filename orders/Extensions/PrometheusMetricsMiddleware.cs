using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Prometheus;

namespace orders
{
    public class PrometheusMetricsMiddleware
    {
        private readonly RequestDelegate next;

        public PrometheusMetricsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            var method = httpContext.Request.Method;

            var counter = Metrics.CreateCounter("dotnet_http_requests_total", "HTTP Requests Total", labelNames: new[] { "path", "method", "status" });
            var summary = Metrics.CreateSummary("dotnet_http_request_duration_milliseconds", "HTTP Request Duration milliseconds", labelNames: new[] { "path", "method", "status" });
            var statusCode = 200;
            var stopWatch = Stopwatch.StartNew();

            try
            {
                await next.Invoke(httpContext);
                stopWatch.Stop();
            }
            catch (Exception)
            {
                statusCode = 500;
                stopWatch.Stop();
                counter.Labels(path, method, statusCode.ToString()).Inc();
                summary.Labels(path, method, statusCode.ToString()).Observe(stopWatch.Elapsed.TotalMilliseconds);
                throw;
            }

            if (path != "/metrics")
            {
                statusCode = httpContext.Response.StatusCode;
                counter.Labels(path, method, statusCode.ToString()).Inc();
                summary.Labels(path, method, statusCode.ToString()).Observe(stopWatch.Elapsed.TotalMilliseconds);
            }
        }
    }
}