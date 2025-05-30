using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Routes.Examples.Sortable;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/sortable");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/Sortable", new { }).ExecuteAsync(this.HttpContext);
    }
}