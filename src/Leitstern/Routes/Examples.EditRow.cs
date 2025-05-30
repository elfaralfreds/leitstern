using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.EditRow;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/edit-row");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/EditRow", new { }).ExecuteAsync(this.HttpContext);
    }
}