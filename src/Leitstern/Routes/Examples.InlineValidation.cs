using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.InlineValidation;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/inline-validation");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/InlineValidation", new { }).ExecuteAsync(this.HttpContext);
    }
}