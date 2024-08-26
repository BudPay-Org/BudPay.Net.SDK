namespace BudPay.Net.SDK.DataTransfers;

public class TransactionEncryptionRequest
{
     public string amount { get; set; }
    public string card { get; set; }
    public string currency { get; set; }
    public string email { get; set; }
    public string reference { get; set; }
}
