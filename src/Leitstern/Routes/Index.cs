using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Frontpage", new { }).ExecuteAsync(this.HttpContext);
    }
}