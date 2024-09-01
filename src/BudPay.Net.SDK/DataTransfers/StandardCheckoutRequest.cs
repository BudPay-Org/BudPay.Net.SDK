namespace BudPay.Net.SDK.DataTransfers;

public class StandardCheckoutRequest
{
     public string email { get; set; } // Required: Customer email address
    public string amount { get; set; } // Required: Amount you are debiting the customer
    public string currency { get; set; } // Optional: Currency charge should be performed in. Default is NGN
    public string reference { get; set; } // Optional: Unique case sensitive transaction reference
    public string callback { get; set; } // Optional: Function that runs when payment is successful
}


