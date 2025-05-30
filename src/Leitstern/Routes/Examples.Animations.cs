using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Features.Animations.Endpoints;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/animations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/Animations", new { }).ExecuteAsync(this.HttpContext);
    }
}