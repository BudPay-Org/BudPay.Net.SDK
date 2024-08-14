namespace BudPay.Net.SDK.DataTransfers;

public class S2SInitializeTransactionRequest
{
    public string amount { get; set; }
    public string card { get; set; }
    public string callback { get; set; }
    public string currency { get; set; }
    public string email { get; set; }
    public string pin { get; set; }
    public string reference { get; set; }
}



