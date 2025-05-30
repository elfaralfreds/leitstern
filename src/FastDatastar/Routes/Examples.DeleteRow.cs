using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Routes.Examples.DeleteRow;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/delete-row");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/DeleteRow", new { }).ExecuteAsync(this.HttpContext);
    }
}