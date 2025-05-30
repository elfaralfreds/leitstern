using FastEndpoints;

namespace Leitstern.Routes.Examples.ProgressBar;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/progressbar");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/ProgressBar", new { }).ExecuteAsync(this.HttpContext);
    }

    
}