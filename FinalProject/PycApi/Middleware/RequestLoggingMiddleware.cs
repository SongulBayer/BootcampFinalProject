using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PycApi
{

    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;


        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                Log.Information("Request {method}  -  {url} => {statusCode}   invoked",
                                 context.Request?.Method,
                                 context.Request?.Path.Value,
                                 context.Response?.StatusCode);


            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            finally
            {
                var originalBodyStream = context.Response.Body;
                var ReqText = await FormatRequest(context.Request);
                var RspText = "";

                if (!context.Request.Path.Value.Contains("/Token"))
                {
                    using (var responseBody = new MemoryStream())
                    {
                        try
                        {
                            context.Response.Body = responseBody;
                            await _next(context);
                            RspText = await FormatResponse(context?.Response);
                            await responseBody.CopyToAsync(originalBodyStream);

                            // log 
                            Log.Information($"ResponseCode= {context.Response.StatusCode} ||  Request= {ReqText}  ||  Response= {RspText} ");
                        }
                        catch (Exception ex)
                        {
                            // log 
                            Log.Information($"ResponseCode= {context.Response.StatusCode} || Error = {ex.ToString()}");
                            await HandleExceptionAsync(context, ex);

                        }
                    }
                }
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error"
            }.ToString());
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var bodyAsText = "";
            try
            {
                using (var bodyReader = new StreamReader(request.Body))
                {
                    bodyAsText = await bodyReader.ReadToEndAsync();
                    request.Body = new MemoryStream(Encoding.UTF8.GetBytes(bodyAsText));
                }
            }
            catch (Exception ex)
            {

            }

            return $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString} {bodyAsText}";
        }
        private async Task<string> FormatResponse(HttpResponse response)
        {
            var sr = new StreamReader(response.Body);
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await sr.ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"Response {text}";
        }

       

    }
}
