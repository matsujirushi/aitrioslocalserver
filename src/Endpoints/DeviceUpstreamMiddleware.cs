using System.Text.RegularExpressions;

namespace aitrioslocalserver.Endpoints;

public class DeviceUpstreamMiddleware
{
    private readonly RequestDelegate _next;
    private Regex _metaFileNamePattern = new Regex(@"^/\d{17}\.txt$");
    private Regex _imageFileNamePattern = new Regex(@"^/\d{17}\.jpg$");

    public DeviceUpstreamMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Method == "PUT")
        {
            PathString remainingPath;
            if (context.Request.Path.StartsWithSegments("/deviceupstream/meta", out remainingPath))
            {
                // ファイル名のチェックと切り取り
                if (!_metaFileNamePattern.IsMatch(remainingPath))
                {
                    await context.Response.WriteAsync("Bad file name.");
                    return;
                }
                var fileName = Path.GetFileName(remainingPath);

                // メタを読み出し
                string meta;
                using (var reader = new StreamReader(context.Request.Body))
                {
                    meta = await reader.ReadToEndAsync();
                }

                Console.WriteLine($"[{fileName} {meta.Length}]");
                return;
            }
            else if (context.Request.Path.StartsWithSegments("/deviceupstream/image", out remainingPath))
            {
                // ファイル名のチェックと切り取り
                if (!_imageFileNamePattern.IsMatch(remainingPath))
                {
                    await context.Response.WriteAsync("Bad file name.");
                    return;
                }
                var fileName = Path.GetFileName(remainingPath);

                // イメージを読み出し
                var image = new MemoryStream();
                await context.Request.Body.CopyToAsync(image);

                Console.WriteLine($"[{fileName} {image.ToArray().Length}]");
                return;
            }
        }

        await _next(context);
    }
}

public static class DeviceUpstreamMiddlewareExtensions
{
    public static IApplicationBuilder UseDeviceUpstreamMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<DeviceUpstreamMiddleware>();
    }
}
