namespace BudPay.Net.SDK.DataTransfers;

public class InternetDataPurchaseResponse
{
    public bool success { get; set; }
    public string code { get; set; }
    public string message { get; set; }
    public InternetDataPurchase data { get; set; }
}

    public class InternetDataPurchase
    {
        public string orderNo { get; set; }
        public string reference { get; set; }
        public string status { get; set; }
        public object errorMsg { get; set; }
    }

   

