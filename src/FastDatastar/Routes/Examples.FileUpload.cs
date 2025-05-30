using FastDatastar.Helpers;
using FastEndpoints;

namespace FastDatastar.Routes.Examples.FileUpload;

public class Index : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/file-upload");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Results.Extensions.View("Sites/Examples/FileUpload", new { }).ExecuteAsync(this.HttpContext);
    }
}