namespace BudPay.Net.SDK.DataTransfers;

public class BulkPayoutResponse
{
    public bool success { get; set; }
    public string message { get; set; }
    public List<PayoutResponseData> data { get; set; }
}

    public class PayoutResponseData
    {
        public string reference { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string fee { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
        public string account_number { get; set; }
        public string account_name { get; set; }
        public string narration { get; set; }
        public string domain { get; set; }
        public string status { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
    }


