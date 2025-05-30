using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.InfiniteScroll;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/infinite-scroll");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/InfiniteScroll", new { }).ExecuteAsync(this.HttpContext);
    }
}