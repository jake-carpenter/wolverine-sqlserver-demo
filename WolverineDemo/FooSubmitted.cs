using Wolverine;

namespace WolverineDemo;

public record FooSubmitted(string Value);

public class FooSubmittedHandler
{
    // This can be async just as easily, but I had no reason to make it async
    public DeliveryMessage<SpeakFooToConsole> Handle(FooSubmitted msg, ILogger logger)
    {
        logger.LogDebug($"➡️Entered {nameof(FooSubmittedHandler)}");

        return new SpeakFooToConsole(msg.Value).WithDeliveryOptions(
            new DeliveryOptions { ScheduledTime = DateTime.UtcNow.AddSeconds(180) });
    }
}