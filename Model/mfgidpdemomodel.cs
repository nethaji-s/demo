using System;
using Newtonsoft.Json;

namespace dotnet_console.Model
{
    public class MfgIdpDemoModel
    {
        public List<VBusbarLineOrderDetails> BLineOrdDetails { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class VBusbarLineOrderDetails
    {
        [JsonProperty("Order Id")]
        public string OrderId { get; set; }

        [JsonProperty("Created On")]
        public string CreatedOn { get; set; }

        [JsonProperty("Requested Delivery Date")]
        public string RequestedDeliveryDate { get; set; }

        [JsonProperty("Required Quantity")]
        public int RequiredQuantity { get; set; }

        [JsonProperty("Customer Name")]
        public string CustomerName { get; set; }

        [JsonProperty("Plant Location")]
        public string PlantLocation { get; set; }

        [JsonProperty("Material Type")]
        public string MaterialType { get; set; }
        public string Dimensions { get; set; }

        [JsonProperty("Requested By")]
        public string RequestedBy { get; set; }

        [JsonProperty("Delivered To")]
        public string DeliveredTo { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }

        [JsonProperty("Job Id")]
        public string JobId { get; set; }

        [JsonProperty("Due Date")]
        public string DueDate { get; set; }

        [JsonProperty("Completion Date")]
        public string CompletionDate { get; set; }

        [JsonProperty("Produced Quantity")]
        public int? ProducedQuantity { get; set; }
        public int? Delivered { get; set; }
        public int? Rejected { get; set; }

        [JsonProperty("Rejected Weight")]
        public string RejectedWeight { get; set; }
    }
}