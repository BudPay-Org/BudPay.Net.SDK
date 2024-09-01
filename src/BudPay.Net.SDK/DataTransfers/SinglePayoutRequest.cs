using Newtonsoft.Json;

namespace BudPay.Net.SDK.DataTransfers;

public class SinglePayoutRequest
{
    public string currency { get; set; } = "NGN";
    
    public string amount { get; set; }
    
    public string bank_code { get; set; }
    
    public string bank_name { get; set; }

    public string account_number { get; set; }
    
    public string narration { get; set; }
    
     
}
