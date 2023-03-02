using Microsoft.AspNetCore.Diagnostics;
using RickAndMortyIntegration.Business.Validation;
using RickAndMortyIntegration.Domain.Models;
using System.Net;

namespace RickAndMortyIntegration.WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    string message;

                    switch (contextFeature?.Error)
                    {
                        case HttpRequestException h:
                            context.Response.StatusCode = (int)h.StatusCode;
                            message = h.Message;
                            break;
                        case RickAndMortyException r:
                            message = r.Message;
                            break;
                        default:
                            message = "Internal Server Error.";
                            break;
                    }

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = message
                        }.ToString());
                    }
                });
            });
        }
    }
}
