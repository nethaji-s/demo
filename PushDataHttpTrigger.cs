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
        // var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "vBusbarLineOrderDetails.json");
        // if (!System.IO.File.Exists(jsonPath))
        // {
        //     return new NotFoundObjectResult("JSON file not found.");
        // }

        // var json = await System.IO.File.ReadAllTextAsync(jsonPath);
        // //var data = JsonSerializer.Deserialize<GenerateRandomMfgIdpDemoModels(10)>(json);

        return new OkObjectResult(GenerateRandomMfgIdpDemoModels(10));
    }
    public static MfgIdpDemoModel GenerateRandomMfgIdpDemoModels(int count)
    {
        //int i = 5;
        var model = new MfgIdpDemoModel();
        model.BLineOrdDetails = new List<VBusbarLineOrderDetails>();
        for (int i = 0; i < count; i++)
        {
            var tmp = new VBusbarLineOrderDetails
            {
                OrderId = $"Order-{i}",
                CreatedOn = DateTime.UtcNow.ToString("o"),
                RequestedDeliveryDate = DateTime.UtcNow.AddDays(7).ToString("o"),
                RequiredQuantity = new Random().Next(1, 100),
                CustomerName = $"Customer-{i}",
                PlantLocation = $"Plant {(char)('A' + new Random().Next(0, 26))}",
                MaterialType = $"Type  {(char)('A' + new Random().Next(0, 26))}",
                Dimensions = $"{new Random().Next(10, 100)}x{new Random().Next(10, 100)}x{new Random().Next(10, 100)}",
                RequestedBy = $"User  {(char)('A' + new Random().Next(0, 26))}",
                DeliveredTo = $"Location  {(char)('A' + new Random().Next(0, 26))}",
                Priority = "High",
                Status = "Pending",
                JobId = $"Job-{i}",
                DueDate = DateTime.UtcNow.AddDays(5).ToString("o"),
                CompletionDate = DateTime.UtcNow.AddDays(10).ToString("o"),
                ProducedQuantity = new Random().Next(0, 100),
                Delivered = new Random().Next(0, 100),
                Rejected = new Random().Next(0, 10),
                RejectedWeight = $"{new Random().Next(0, 10)}kg"
            };
            model.BLineOrdDetails.Add(tmp);
        }


        return model;
    }

}