using Microsoft.Extensions.FileProviders;
using VariacaoAtivoApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables(); builder.Services.ConfigureEntityFramework(builder.Configuration);

builder.Services.ConfiguracaoCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.RegisterServices();

var webRoot = Path.Combine(builder.Environment.ContentRootPath, "wwwroot");
if (!Directory.Exists(webRoot))
{
    Directory.CreateDirectory(webRoot);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.ConfiguracaoCors();

app.UseStaticFiles();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "browser")),
    RequestPath = ""
});

app.MapFallbackToFile("browser/index.html");

app.Run();
