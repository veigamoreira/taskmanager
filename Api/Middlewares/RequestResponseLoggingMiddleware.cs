namespace Api.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("➡️ Request {method} {url}", context.Request.Method, context.Request.Path);

            await _next(context);

            _logger.LogInformation("⬅️ Response {statusCode}", context.Response.StatusCode);
        }
    }

}
