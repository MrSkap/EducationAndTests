using MediatrExample.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((context, _) =>
{
    var level = context.HostingEnvironment.IsDevelopment() ? LogEventLevel.Debug : LogEventLevel.Information;
    var logger = new LoggerConfiguration()
        .WriteTo.Console(level, "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message}{NewLine}{Exception}")
        .CreateLogger();
    Log.Logger = logger;
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.AddControllers();
builder.Services.AddMediatrExample();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.Services.GetService<ILoggerFactory>()?.AddSerilog();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();