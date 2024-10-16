using Spectre.Console;
using Wolverine;

namespace WolverineDemo;

public class SpeakFooToConsole(string value) : ISideEffect
{
    public void Execute(ILogger logger)
    {
        logger.LogDebug($"➡️Entered {nameof(SpeakFooToConsole)}");
        AnsiConsole.Write(new FigletText(value).Centered().Color(Color.Green));
    }
}

