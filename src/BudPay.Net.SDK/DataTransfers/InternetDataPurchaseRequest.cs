namespace BudPay.Net.SDK.DataTransfers;

public class InternetDataPurchaseRequest
{
     public string provider { get; set; }
    public string number { get; set; }
    public string plan_id { get; set; }
    public string reference { get; set; }
}