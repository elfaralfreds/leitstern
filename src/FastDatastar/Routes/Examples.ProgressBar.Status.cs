using FastEndpoints;
using FastDatastar.Helpers;
using StarFederation.Datastar.DependencyInjection;

namespace FastDatastar.Routes.Examples.ProgressBar;

public class Status : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/examples/progressbar/status");
        AllowAnonymous();
        // Options(x => x.RequireCors(p => p.AllowAnyOrigin()));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var actionType = this.HttpContext.Request.Query["actionType"];
        
        IDatastarServerSentEventService? sse = TryResolve<IDatastarServerSentEventService>();
        if (sse == null)
        {
            await SendAsync("Server-Sent Events not available", 500);
            return;
        }

        if (actionType == "start")
        {
            for(var i = 0; i <= 100; i +=7)
            {
                await sse.MergeFragmentsAsync(await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "_Partials/ProgressBarStatus", new { Progress = i }));
                await Task.Delay(300);
            }
            await sse.MergeFragmentsAsync(await Results.Extensions.ViewAsString(this.HttpContext.Duplicate(), "_Partials/ProgressBarDone", new { }));
        }
    }
}