using Leitstern.Helpers;
using FastEndpoints;
using Microsoft.AspNetCore.Components.Routing;

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
        await Results.Extensions.View("Sites/Frontpage", _.Leitstern()).ExecuteAsync(this.HttpContext);
    }
}