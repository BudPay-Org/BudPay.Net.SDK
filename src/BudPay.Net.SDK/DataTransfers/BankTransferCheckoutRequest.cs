namespace BudPay.Net.SDK.DataTransfers;

public class BankTransferCheckoutRequest
{
     public string email { get; set; }
    public string amount { get; set; }
    public string currency { get; set; }
    public string reference { get; set; }
    public string name { get; set; }
}


