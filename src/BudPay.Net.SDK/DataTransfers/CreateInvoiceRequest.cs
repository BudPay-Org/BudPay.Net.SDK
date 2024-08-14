namespace BudPay.Net.SDK.DataTransfers;

public class CreateInvoiceRequest
{
     public string title { get; set; }
    public string duedate { get; set; }
    public string currency { get; set; }
    public string invoicenumber { get; set; }
    public string reminder { get; set; }
    public string email { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string billing_address { get; set; }
    public string billing_city { get; set; }
    public string billing_state { get; set; }
    public string billing_country { get; set; }
    public string billing_zipcode { get; set; }
    public List<InvoiceItem> items { get; set; }
    
}

    public class InvoiceItem
    {
        public string description { get; set; }
        public string quantity { get; set; }
        public string unit_price { get; set; }
        public string meta_data { get; set; }
    }


