namespace BudPay.Net.SDK.DataTransfers;

public class CardDetailsRequest
{
     public CardDetails data { get; set; }
     public string reference { get; set; }
}

    public class CardDetails
    {
        public string number { get; set; }
        public string expiryMonth { get; set; }
        public string expiryYear { get; set; }
        public string cvv { get; set; }
        public string pin { get; set; }
    }



