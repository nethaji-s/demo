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
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("test!");
    }
}