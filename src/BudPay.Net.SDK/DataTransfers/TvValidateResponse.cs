namespace BudPay.Net.SDK.DataTransfers;

public class TvValidateResponse
{
    public bool success { get; set; }
    public string code { get; set; }
    public string message { get; set; }
    public TvValidateData data { get; set; }
}

    public class TvValidateData
    {
        public string orderNo { get; set; }
        public string reference { get; set; }
        public string status { get; set; }
        public object errorMsg { get; set; }
    }
