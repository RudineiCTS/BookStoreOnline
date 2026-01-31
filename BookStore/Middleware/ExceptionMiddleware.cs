using MyFirstApp.Communication.Response;

namespace MyFirstApp.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public  ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(NotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                var errorResponse = new ResponseErrorsJson
                {
                    Errors = new List<string> { ex.Message }
                };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var errorResponse = new ResponseErrorsJson
                {
                    Errors = new List<string> { "Internal server error." }
                };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
