namespace BudPay.Net.SDK.DataTransfers;

public class ElectricityRechargeRequest
{
    public string provider { get; set; }
    public string number { get; set; }
    public string type { get; set; }
    public int amount { get; set; }
    public string reference { get; set; }
}

