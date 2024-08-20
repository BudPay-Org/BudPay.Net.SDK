namespace BudPay.Net.SDK.DataTransfers;

public class ElectricityProviderResponse
{
       public bool success { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public List<ElectricityProviderDatum> data { get; set; }
}

    public class ElectricityProviderDatum
    {
        public string provider { get; set; }
        public string code { get; set; }
        public string providerLogoUrl { get; set; }
        public string minAmount { get; set; }
    }

