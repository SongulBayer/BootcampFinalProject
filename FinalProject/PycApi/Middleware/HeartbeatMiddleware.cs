using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PycApi.Middleware
{
    public class HeartbeatMiddleware
    {
        private readonly RequestDelegate next;

        public HeartbeatMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/heartbeat"))
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Hello from the server");
                return;
            }

            if (context.Request.Path.StartsWithSegments("/pyc"))
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Internal Server Error");
                return;
            }

            await next.Invoke(context);
        }
    }
}