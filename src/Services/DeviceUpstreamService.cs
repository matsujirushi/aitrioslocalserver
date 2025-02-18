using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace aitrioslocalserver.Services;

public class DeviceUpstreamService
{
    public DeviceUpstreamService()
    {
        Console.WriteLine("DeviceUpstreamService()");
    }

    public void Map(IEndpointRouteBuilder app)
    {
        var deviceApi = app.MapGroup("/deviceupstreamold");

        deviceApi.MapGet("/meta/{fileName}", PutMeta);
    }

    private IResult PutMeta(HttpContext context, string fileName)
    {
        MetaReceived?.Invoke(null, new EventArgs());

        return Results.Ok();
    }

    public event EventHandler<EventArgs>? MetaReceived;
}
