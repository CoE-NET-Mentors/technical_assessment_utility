using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
        .Enrich.FromLogContext()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .WriteTo.Console()
    );
    builder.Services.AddControllers();
    builder.Services.AddSpaStaticFiles(configure => configure.RootPath = "wwwroot");
}
var app = builder.Build();
{
    app.UseExceptionHandler("/api/Error/500");
    app.UseStatusCodePagesWithReExecute("/api/Error/{0}");
    app.UseSerilogRequestLogging();
    if (!app.Environment.IsDevelopment())
    {
        app.UseHsts();
        const string cacheMaxAge = "1440";
        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                // using Microsoft.AspNetCore.Http;
                ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cacheMaxAge}");
            }
        });
    }
    else
    {
        app.UseStaticFiles();
    }

    app.MapControllers();

    app.UseSpa(options => options.Options.DefaultPage = new Microsoft.AspNetCore.Http.PathString("/index.html"));

}
app.Run();
