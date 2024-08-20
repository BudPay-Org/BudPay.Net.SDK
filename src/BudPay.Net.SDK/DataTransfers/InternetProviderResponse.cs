namespace BudPay.Net.SDK;

public class InternetProviderResponse
{
    public bool success { get; set; }
    public string code { get; set; }
    public string message { get; set; }
    public List<InternetProviders> data { get; set; }
}


    public class InternetProviders
    {
        public int id { get; set; }
        public string provider { get; set; }
        public string providerLogoUrl { get; set; }
    }


