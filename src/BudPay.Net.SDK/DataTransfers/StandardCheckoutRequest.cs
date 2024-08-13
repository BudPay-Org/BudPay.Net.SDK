namespace BudPay.Net.SDK.DataTransfers;

public class StandardCheckoutRequest
{
     public string Email { get; set; } // Required: Customer email address
    public string Amount { get; set; } // Required: Amount you are debiting the customer
    public string Currency { get; set; } // Optional: Currency charge should be performed in. Default is NGN
    public string Reference { get; set; } // Optional: Unique case sensitive transaction reference
    public string Callback { get; set; } // Optional: Function that runs when payment is successful
}


