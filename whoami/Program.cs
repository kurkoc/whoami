var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("health", () => Results.Ok());

app.MapGet("/", async (HttpContext context, IHostEnvironment environment) =>
{
    string message = $"""
                      machine name: {Environment.MachineName}
                      environment name: {environment.EnvironmentName} 
                      trace id: {context.Request.HttpContext.TraceIdentifier} 
                      protocol: {context.Request.Protocol} 
                      method: {context.Request.Method}
                      contentRoot: {environment.ContentRootPath}
                      path: {context.Request.Path}
                      os version: {Environment.OSVersion.VersionString}
                      processors: {Environment.ProcessorCount}
                      """;
    
    await context.Response.WriteAsync(message);
});

app.Run();