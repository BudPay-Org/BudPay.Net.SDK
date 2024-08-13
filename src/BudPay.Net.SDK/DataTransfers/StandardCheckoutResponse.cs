namespace BudPay.Net.SDK.DataTransfers;

public class StandardCheckoutResponse
{
     public bool status { get; set; }
     public string message { get; set; }
     public StandardCheckoutResponseData data { get; set; }
}

    public class StandardCheckoutResponseData
    {
        public string authorization_url { get; set; }
        public string access_code { get; set; }
        public string reference { get; set; }
    }

  

