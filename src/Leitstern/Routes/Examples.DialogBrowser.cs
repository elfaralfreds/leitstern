using Leitstern.Helpers;
using FastEndpoints;

namespace Leitstern.Routes.Examples.DialogsBrowser;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/dialog-browser");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/DialogsBrowser", new { }).ExecuteAsync(this.HttpContext);
    }
}