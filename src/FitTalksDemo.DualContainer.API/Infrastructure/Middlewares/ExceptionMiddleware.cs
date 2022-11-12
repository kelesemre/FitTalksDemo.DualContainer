using System;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using FitTalksDemo.DualContainer.Common.Response;
using FitTalksDemo.DualContainer.Common.Exceptions;

namespace FitTalksDemo.DualContainer.API.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next,
                                   ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex, null, ex.StatusCode);
            }
            catch (DomainException ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex, null, ex.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex, null);
            }
        }
        /// <summary>
        /// Return Generic Response in case of error
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <param name="errorList">Validation Error List</param>
        /// <param name="statusCode">Error Code</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context,
                                          Exception ex,
                                          List<string> errorList,
                                          int statusCode = (int)HttpStatusCode.InternalServerError)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var returnObject = (errorList is null) ? GenericResponse<string>.Fail(ex.Message) :
                                                     GenericResponse<string>.Fail(errorList);
            return context.Response.WriteAsync(JsonConvert.SerializeObject(returnObject));
        }
    }
}
