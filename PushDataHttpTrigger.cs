using System.Text.Json;
using dotnet_console.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace mfgidpdemo.Function;

public class PushDataHttpTrigger
{
    private readonly ILogger<PushDataHttpTrigger> _logger;

    public PushDataHttpTrigger(ILogger<PushDataHttpTrigger> logger)
    {
        _logger = logger;
    }

    [Function("PushDataHttpTrigger")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        //Adjust the path as needed
        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "vBusbarLineOrderDetails.json");
        if (!System.IO.File.Exists(jsonPath))
        {
            return new NotFoundObjectResult("JSON file not found.");
        }

        var json = await System.IO.File.ReadAllTextAsync(jsonPath);
        var data = JsonSerializer.Deserialize<List<MfgIdpDemoModel>>(json);

        return new OkObjectResult(data);
    }
}