using Wolverine.Http;

namespace WolverineDemo;

public record SubmitFooBody(string Value);

public class FooEndpoint
{
    [WolverinePost("/foo")]
    public void Handle(SubmitFooBody body)
    {
        Console.WriteLine($"Received: {body.Value}");
    }
}