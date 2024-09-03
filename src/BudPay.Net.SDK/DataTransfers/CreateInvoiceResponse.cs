namespace BudPay.Net.SDK.DataTransfers;

public class CreateInvoiceResponse
{
    public bool success { get; set; }
    public string message { get; set; }
    public InvoiceResponse data { get; set; }
}

    public class InvoiceResponse
    {
        public string invoice_id { get; set; }
        public int ref_id { get; set; }
        public string paycode { get; set; }
        public string redirect_link { get; set; }
    }


