﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using RestaurantApi.Exceptions;
using System;
using System.Threading.Tasks;

namespace RestaurantApi.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundExeption)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundExeption.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something was wrong");
            }
        }
    }
}
