namespace BudPay.Net.SDK.DataTransfers;

public class VerifyPayoutResponse
{
     public bool status { get; set; }
    public string message { get; set; }
    public VerifyPayout data { get; set; }
}

    public class VerifyPayout
    {
        public int id { get; set; }
        public string reference { get; set; }
        public object sessionid { get; set; }
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
        public object subaccount { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

