namespace BudPay.Net.SDK.DataTransfers;

public class TvPackageResponse
{
    public bool success { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public List<TvPackageDatum> data { get; set; }
}

    public class TvPackageDatum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string amount { get; set; }
    }
    

