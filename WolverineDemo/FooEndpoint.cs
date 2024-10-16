using Wolverine;
using Wolverine.Http;

namespace WolverineDemo;

public record SubmitFooBody(string Value);

public class FooEndpoint(ILogger<FooEndpoint> logger, IMessageBus bus)
{
    [WolverinePost("/foo")]
    public async Task<IResult> Handle(SubmitFooBody body)
    {
        logger.LogDebug($"➡️Entered {nameof(FooEndpoint)}");
        var msg = new FooSubmitted(body.Value);
        await bus.SendAsync(msg);
        
        logger.LogDebug($"⬅️Leaving {nameof(FooEndpoint)}");

        return Results.Ok();
    }
}
