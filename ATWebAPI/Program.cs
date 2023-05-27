using ATWebAPI;
using ATWebAPI.CustomMiddlewares;
using EFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Win32;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ATWebDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ATWebAPI")));
ServiceInjections.Register(builder.Services,builder.Configuration);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AT Api v1");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseMiddleware<CustomExceptionMiddleware>();
app.Run();
