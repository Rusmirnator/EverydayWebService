using Everyday.Application.Common.Interfaces.Structures;
using Everyday.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Everyday.API.Middleware
{
    public class ErrorHandlingMeddleware : IMiddleware
    {
        #region Fields & Properties
        private readonly ILogger<ErrorHandlingMeddleware> logger;
        #endregion

        #region CTOR
        public ErrorHandlingMeddleware(ILogger<ErrorHandlingMeddleware> logger)
        {
            this.logger = logger;
        }
        #endregion

        #region Public API
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        #endregion

        #region Private API
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpResponse response = context.Response;

            IOperationResult operationResult;

            switch (exception)
            {
                case ApplicationException ex:

                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    operationResult = new OperationResultModel(false, ex.Message);
                    break;

                default:

                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    operationResult = new OperationResultModel(false, HttpStatusCode.InternalServerError.ToString());
                    break;
            }

            logger.LogError(exception.Message);

            await context.Response.WriteAsync(JsonSerializer.Serialize(operationResult));
        }
        #endregion
    }
}