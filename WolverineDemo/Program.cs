using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWolverine();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapWolverineEndpoints();

app.Run();