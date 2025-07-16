﻿using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using University.Core.Exceptions;

namespace University.api.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;
        
        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                _logger.LogWarning(context.Exception, "Item not found");
                context.Result = Response(context.Exception.Message, "item not found", StatusCodes.Status404NotFound);
                return;
            }

            if (context.Exception is BusinessException businessException)
            {
                if (businessException.Errors.Any())
                {
                    context.Result = Response(businessException.Errors, "One or more business validation errors occurred.", StatusCodes.Status400BadRequest);
                }
                else
                {
                    context.Result = Response(businessException.Message, "One or more business validation errors occurred.", StatusCodes.Status400BadRequest);
                }
                return;
            }

            if (context.Exception is ArgumentNullException)
            {
                context.Result = Response(context.Exception.Message, "missing data", StatusCodes.Status400BadRequest);
                return;
            }

            if (context.Exception is UnauthorizedAccessException)
            {
                context.Result = Response(context.Exception.Message, "Unauthorized", StatusCodes.Status403Forbidden);
                return;
            }

            _logger.LogError(context.Exception, "An unhandled exception occurred.");

            context.Result = Response(context.Exception.Message, "Internal Server Error", StatusCodes.Status500InternalServerError);
        }

        private ObjectResult Response(string message, string title, int status, string? stackTrace = null)
        {
            var result = new ApiResponse
            {
               StatusCode = status,
               Message = message,
               ResponseException = title,
               IsError = true,
               Version = "1.0",
               Result = stackTrace
            };

            return new ObjectResult(result)
            {
                StatusCode = status
            };
        }

        private ObjectResult Response(Dictionary<string, List<string>> errors, string title, int status)
        {
            var result = new ApiResponse
            {
                StatusCode = status,
                Message = title,
                ResponseException = title,
                IsError = true,
                Version = "1.0",
                Result = errors
            };
            return new ObjectResult(result)
            {
                StatusCode = status
            };
        }


    }
}
