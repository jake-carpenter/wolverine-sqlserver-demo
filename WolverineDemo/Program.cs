using Oakton;
using Oakton.Resources;
using Wolverine;
using Wolverine.Http;
using Wolverine.SqlServer;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ApplyOaktonExtensions();
builder.Services.AddResourceSetupOnStartup();
builder.Host.UseWolverine(
    opt =>
    {
        opt.Services.AddLogging(x => x.AddConsole());

        // Too lazy to moe this into config for now.
        const string connectionString =
            "Data Source=localhost,9986;Database=master;User Id=sa;Password=Password123;TrustServerCertificate=True;";
        
        // SQL Server transport
        opt.UseSqlServerPersistenceAndTransport(connectionString, "wolverine").AutoProvision();
        opt.PublishAllMessages().ToSqlServerQueue("demo_events");
        opt.ListenToSqlServerQueue("demo_events");
        opt.Policies.AutoApplyTransactions();
        opt.Policies.UseDurableInboxOnAllListeners();
        opt.Policies.UseDurableOutboxOnAllSendingEndpoints();
        opt.Policies.UseDurableLocalQueues();
    }).UseResourceSetupOnStartup();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapWolverineEndpoints();

return await app.RunOaktonCommands(args);