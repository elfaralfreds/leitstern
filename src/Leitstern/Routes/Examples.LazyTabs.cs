using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.LazyTabs;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/lazy-tabs");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/LazyTabs", new { }).ExecuteAsync(this.HttpContext);
    }
}