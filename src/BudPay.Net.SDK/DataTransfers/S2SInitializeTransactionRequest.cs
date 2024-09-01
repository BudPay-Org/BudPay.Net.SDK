namespace BudPay.Net.SDK.DataTransfers;

public class S2SInitializeTransactionRequest
{
    public string Amount { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryYear { get; set; }
    public string ExpiryMonth { get; set; }
    public string CVV { get; set; }
    public string Callback { get; set; }
    public string Currency { get; set; }
    public string Email { get; set; }
    public string Pin { get; set; }
    public string Reference { get; set; }
   
}



