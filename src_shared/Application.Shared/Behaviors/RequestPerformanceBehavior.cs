using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Shared.Behaviors;

public class RequestPerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;

    const long SlowRequestThresholdMilliseconds = 500;
    const long VerySlowRequestThresholdMilliseconds = 2000;

    public RequestPerformanceBehavior(
        ILogger<TRequest> logger)
    {
        _timer = new Stopwatch();

        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > SlowRequestThresholdMilliseconds) {
            if (elapsedMilliseconds > VerySlowRequestThresholdMilliseconds) {   
                _logger.LogCritical($"VERY Slow Request Detected: {request.GetType().FullName} , elapsed milliseconds: {elapsedMilliseconds} milliseconds)");

            } else {
                _logger.LogWarning($"Slow Request Detected: {request.GetType().FullName} , elapsed milliseconds: {elapsedMilliseconds} milliseconds)");
            }
        }
        return response;
    }
}
