using Newtonsoft.Json;

namespace InvoiceAutomation.Models
{
    public class Invoice
    {           
        [JsonProperty("Id")]
        public int? Id { get; set; }
        [JsonProperty("Invoice_Number")]
        public string Invoice_Number { get; set; }
        [JsonProperty("Document_Number")]
        public int Document_Number { get; set; } = 0;
        [JsonProperty("Data_Of_Creation")]
        public DateTime Data_Of_Creation { get; set; }
        [JsonProperty("Sender_Code")]
        public string Sender_Code { get; set; }
        [JsonProperty("Recipient_Code")]
        public string Recipient_Code { get; set; }
        [JsonProperty("Cost_Code")]
        public string Cost_Code { get; set; } = "Не работает";
        [JsonProperty("Name")]
        public string Name { get; set; } = "Не работает";
        [JsonProperty("Item_Number")]
        public string Item_Number { get; set; } = "Не работает";
        [JsonProperty("Unit")]
        public string Unit { get; set; }
        [JsonProperty("Quantity")]
        public int Quantity { get; set; } = 99;
        [JsonProperty("Price")]
        public float Price { get; set; } = 99;
        [JsonProperty("Allowed")]
        public string Allowed { get; set; }
        [JsonProperty("Controller")]
        public string Controller { get; set; }
        [JsonProperty("Passed")]
        public string Passed { get; set; }
        [JsonProperty("Accepted")]
        public string Accepted { get; set; }
    }
}
