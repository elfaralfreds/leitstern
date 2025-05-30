using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.ClickToLoad;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/click-to-load");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/ClickToLoad", new { }).ExecuteAsync(this.HttpContext);
    }
}