namespace InvoiceAutomation.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Invoice_Number { get; set; }
        public int Document_Number { get; set; } = 0;
        public DateTime Data_Of_Creation { get; set; }
        public string Sender_Code { get; set; } 
        public string Recipient_Code { get; set; }
        public string Cost_Code { get; set; } = "Не работает";
        public string Name { get; set; } = "Не работает";
        public string Item_Number { get; set; } = "Не работает";
        public string Unit { get; set; }
        public int Quantity { get; set; } = 99;
        public float Price { get; set; } = 99;
        public string Allowed { get; set; }
        public string Controller { get; set; }
        public string Passed { get; set; }
        public string Accepted { get; set; }
    }
}
