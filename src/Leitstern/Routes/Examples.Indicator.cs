using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.Indicator;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/indicator");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/Indicator", new { }).ExecuteAsync(this.HttpContext);
    }
}