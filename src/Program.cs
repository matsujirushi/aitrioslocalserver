using aitrioslocalserver.Components;
using aitrioslocalserver.Endpoints;
using aitrioslocalserver.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

var deviceUpstreamService = new DeviceUpstreamService();
builder.Services.AddSingleton(deviceUpstreamService);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapInferenceDataUpload();
deviceUpstreamService.Map(app);

app.UseDeviceUpstreamMiddleware();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
