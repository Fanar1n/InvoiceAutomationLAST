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
        public int Serial_Number { get; set; }
        public string Cost_Code { get; set; }
        public string Name { get; set; }
        public string Item_Number { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Sum { get; set; }
        public string Allowed { get; set; }
        public string Controller { get; set; }
        public string Passed { get; set; }
        public string Accepted { get; set; }
    }
}
