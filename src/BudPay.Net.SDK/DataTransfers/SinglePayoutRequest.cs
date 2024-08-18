namespace BudPay.Net.SDK.DataTransfers;

public class SinglePayoutRequest
{
    public string Currency { get; set; } = "NGN";
    
    public string Amount { get; set; }
    
    public string BankCode { get; set; }
    
    public string BankName { get; set; }
    
    public string AccountNumber { get; set; }
    
    public string Narration { get; set; }
    
    public string PaymentMode { get; set; }
    
    public string Reference { get; set; }
}
