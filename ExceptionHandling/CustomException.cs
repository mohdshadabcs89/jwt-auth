using jwt_token.Model;
using System.Net;

namespace jwt_token.ExceptionHandling
{

    public class CustomException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomException> _logger;
        public CustomException(RequestDelegate next, ILogger<CustomException> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception raised - {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Internal Server Error - {exception.Message}"
            }.ToString());
        }
    }
}
