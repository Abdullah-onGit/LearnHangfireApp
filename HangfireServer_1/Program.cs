using Common;
using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var _services = builder.Services;
var _config = builder.Configuration;
_services.AddCommonServices();
// Add Hangfire services.
_services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(_config.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));
_services.AddHangfireServer();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
