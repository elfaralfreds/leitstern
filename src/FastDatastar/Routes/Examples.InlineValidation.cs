using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Routes.Examples.InlineValidation;

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