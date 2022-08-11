using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Everyday.Core.Shared;
using Microsoft.AspNetCore.Http;
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

        public async Task InvokeAsync(HttpContext context)
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

                var result = JsonConvert.SerializeObject(new { message = error?.Message });

                await response.WriteAsync(result);
            }
        }
    }
}