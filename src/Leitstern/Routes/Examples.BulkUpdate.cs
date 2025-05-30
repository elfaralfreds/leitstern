using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Features.BulkUpdate.Endpoints;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/bulk-update");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/BulkUpdate", new { }).ExecuteAsync(this.HttpContext);
    }
}