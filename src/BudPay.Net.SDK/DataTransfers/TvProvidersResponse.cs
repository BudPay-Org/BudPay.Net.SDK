namespace BudPay.Net.SDK.DataTransfers;

public class TvProvidersResponse
{
     public bool success { get; set; }
    public string code { get; set; }
    public string message { get; set; }
    public List<TvProvidersDatum> data { get; set; }
}

    public class TvProvidersDatum
    {
        public string provider { get; set; }
        public string providerLogoUrl { get; set; }
    }

