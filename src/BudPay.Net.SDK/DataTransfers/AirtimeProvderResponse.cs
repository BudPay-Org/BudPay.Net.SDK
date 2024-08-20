namespace BudPay.Net.SDK.DataTransfers;

public class AirtimeProvderResponse
{
     public bool success { get; set; }
    public string code { get; set; }
    public string message { get; set; }
    public List<AirtimeProvderData> data { get; set; }
}

    public class AirtimeProvderData
    {
        public string provider { get; set; }
        public string providerLogoUrl { get; set; }
        public string minAmount { get; set; }
        public string maxAmount { get; set; }
    }

 


