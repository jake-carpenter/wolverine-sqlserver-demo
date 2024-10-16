using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWolverine(opt =>
{
    opt.Services.AddLogging(x => x.AddConsole());
});

var app = builder.Build();
app.UseHttpsRedirection();
app.MapWolverineEndpoints();

app.Run();