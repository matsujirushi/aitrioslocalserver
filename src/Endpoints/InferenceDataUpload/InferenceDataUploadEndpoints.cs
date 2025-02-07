using Google.FlatBuffers;
using SmartCamera;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Nodes;

public static class InferenceDataUploadEndpoints
{
    public static void MapInferenceDataUpload(this IEndpointRouteBuilder app)
    {
        var deviceApi = app.MapGroup("/api/inferencedataupload");

        deviceApi.MapPut("/meta/{fileName}", PutMeta);
        deviceApi.MapPut("/image/{fileName}", PutImage);
    }

    private static async Task<IResult> PutMeta(HttpContext context, string fileName)
    {
        Debug.WriteLine($"Meta \"{fileName}\" received");

        // HTTP PUTのコンテンツを読み出し
        using var reader = new StreamReader(context.Request.Body);
        var content = await reader.ReadToEndAsync();

        // コンテンツをJSONに変換してTransfer()を呼び出し
        using (var metasDocument = JsonDocument.Parse(content))
        {
            var metas = metasDocument.RootElement;
            
            if (metas.TryGetProperty("DeviceID", out var deviceId) &&
                metas.TryGetProperty("ModelID", out var modelId) &&
                metas.TryGetProperty("Inferences", out var inferences))
            {
                foreach (var inference in inferences.EnumerateArray())
                {
                    if (inference.TryGetProperty("T", out var time) &&
                        inference.TryGetProperty("O", out var obj))
                    {
                        // FlatBuffersデコード
                        var objStr = DecodeFlatBuffersObjectDetectionFlatBuffers(obj);
                        if (objStr != null)
                        {
                            // 新しくJSONを構築
                            var metaObject = new JsonObject();
                            metaObject["DeviceID"] = JsonValue.Create(deviceId);
                            metaObject["ModelID"] = JsonValue.Create(modelId);
                            metaObject["T"] = JsonValue.Create(time);
                            metaObject["O"] = JsonNode.Parse(objStr);

                            await ActionMeta(fileName, metaObject);
                        }
                    }
                }
            }
        }

        return Results.Ok();
    }

    private static string? DecodeFlatBuffersObjectDetectionFlatBuffers(JsonElement obj)
    {
        if (!obj.TryGetBytesFromBase64(out var objBytes)) return null;

        var objectDetection = ObjectDetectionTop.GetRootAsObjectDetectionTop(new ByteBuffer(objBytes));
        ObjectDetectionTopT objectDetectionT = objectDetection.UnPack();
        return objectDetectionT.SerializeToJson();
    }

    private static async Task ActionMeta(string fileName, JsonObject metaObject)
    {
        using (var file = new StreamWriter(Path.Combine(META_DIRECTORY, fileName)))
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            await file.WriteAsync(JsonSerializer.Serialize(metaObject, options));
        }

        if (MetaReceived != null)
        {
            Debug.WriteLine($"Invoke meta to {MetaReceived?.GetInvocationList().Length} handler(s)");
            MetaReceived?.Invoke(null, new MetaReceivedEventArgs() { Meta = metaObject.ToJsonString() });
        }
    }

    private static async Task<IResult> PutImage(HttpContext context, string fileName)
    {
        Debug.WriteLine($"Image \"{fileName}\" received");

        // HTTP PUTのコンテンツをファイルに保存
        var body = context.Request.Body;
        using (var file = new FileStream(Path.Combine(IMAGE_DIRECTORY, fileName), FileMode.Create, FileAccess.Write))
        {
            var buffer = new byte[READ_BUFFER_SIZE];
            int bufferReadSize;
            while ((bufferReadSize = await body.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await file.WriteAsync(buffer, 0, bufferReadSize);
            }
        }

        ActionImage(fileName);

        return Results.Ok();
    }

    private static void ActionImage(string fileName)
    {
        if (ImageReceived != null)
        {
            Debug.WriteLine($"Invoke image to {ImageReceived?.GetInvocationList().Length} handler(s)");
            ImageReceived?.Invoke(null, new ImageReceivedEventArgs() { ImageFileName = fileName });
        }
    }

    public static event EventHandler<MetaReceivedEventArgs>? MetaReceived;
    public static event EventHandler<ImageReceivedEventArgs>? ImageReceived;

    private const string META_DIRECTORY = "./wwwroot/inferencedata/meta";
    private const string IMAGE_DIRECTORY = "./wwwroot/inferencedata/image";
    private const int READ_BUFFER_SIZE = 4096;
}

public class MetaReceivedEventArgs : EventArgs
{
    public string? Meta { get; set; }
}

public class ImageReceivedEventArgs : EventArgs
{
    public string? ImageFileName { get; set; }
}
