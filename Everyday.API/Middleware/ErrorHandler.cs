using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Everyday.Core.Shared;
using Everyday.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Everyday.API.Middleware
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<ErrorHandler> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException _:

                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException _:

                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:

                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                logger.LogError(error.Message);
                var result = JsonConvert.SerializeObject(new { message = error?.Message, innerMessage = error?.InnerException?.Message });

                await response.WriteAsync(result);
            }
        }
    }
}