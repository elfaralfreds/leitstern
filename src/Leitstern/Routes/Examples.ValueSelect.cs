using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.ValueSelect;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/value-select");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/ValueSelect", new { }).ExecuteAsync(this.HttpContext);
    }
}