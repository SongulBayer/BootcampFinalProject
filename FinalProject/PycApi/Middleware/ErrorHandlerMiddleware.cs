using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace PycApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var messageError = string.Empty;


                messageError = "Internal Server Error";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // file logging 

                Log.Error("ErrorHandlerMiddleware", error.Message);
                var result = JsonSerializer.Serialize(messageError);
                await response.WriteAsync(result);
            }
        }

    }
}
