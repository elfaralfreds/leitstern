using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.DeleteRow;

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