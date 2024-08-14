namespace BudPay.Net.SDK.DataTransfers;

public class PaymentLinkRequest
{
    public string name { get; set; }
    public string amount { get; set; }
    public string currency { get; set; }
    public string description { get; set; }
    public string redirect { get; set; }
    public string type { get; set; }
    public string interval { get; set; }
    public int times { get; set; }
    public string custom_url { get; set; }
    public string paycode { get; set; }
}
