using Wolverine.Http;

namespace WolverineDemo;

public record SubmitFooBody(string Value);

public class FooEndpoint(ILogger<FooEndpoint> logger)
{
    [WolverinePost("/foo")]
    public (IResult, SpeakFooAfterDelay) Handle(SubmitFooBody body)
    {
        logger.LogInformation("Entered FooEndpoint");
        var msg = new SpeakFooAfterDelay(body.Value);
        logger.LogInformation("Leaving FooEndpoint");
        
        return (Results.Ok(), msg);
    }
}

public record SpeakFooAfterDelay(string Value);

public class SpeakFooAfterDelayHandler
{
    public async Task Handle(SpeakFooAfterDelay msg, ILogger logger)
    {
        logger.LogInformation($"Entered {nameof(SpeakFooAfterDelayHandler)}");
        await Task.Delay(5000);
        Console.WriteLine($"{msg.Value}");
        logger.LogInformation($"Leaving {nameof(SpeakFooAfterDelayHandler)}");
    }
}