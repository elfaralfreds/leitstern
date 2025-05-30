using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Routes.Examples.LazyLoad;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/lazy-load");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/LazyLoad", new { }).ExecuteAsync(this.HttpContext);
    }
}