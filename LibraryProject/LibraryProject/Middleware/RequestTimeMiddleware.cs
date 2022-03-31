using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LibraryProject.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private Stopwatch _stopwatch;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            var elapsedMillliseconds = _stopwatch.ElapsedMilliseconds;
            if (elapsedMillliseconds / 1000 > 5)
            {
                var message = $"Request[{context.Request.Method} at {context.Request.Path} took {elapsedMillliseconds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}