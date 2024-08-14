namespace BudPay.Net.SDK.DataTransfers;

public class VerifyCollectionTransactionResponse
{
    public bool status { get; set; }
    public string message { get; set; }
    public TransactionData data { get; set; }
    public object fees { get; set; }
    public TransactionCustomer customer { get; set; }
    public object plan { get; set; }
    public string requested_amount { get; set; }
}

    public class TransactionCustomer
    {
        public int id { get; set; }
        public string customer_code { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public string email { get; set; }
    }

    public class TransactionData
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public object transaction_date { get; set; }
        public string reference { get; set; }
        public string domain { get; set; }
        public object gateway_response { get; set; }
        public object channel { get; set; }
        public object ip_address { get; set; }
        public TransactionLog log { get; set; }
    }

    public class History
    {
        public string type { get; set; }
        public string message { get; set; }
        public int time { get; set; }
    }

    public class TransactionLog
    {
        public int time_spent { get; set; }
        public int attempts { get; set; }
        public object authentication { get; set; }
        public int errors { get; set; }
        public bool success { get; set; }
        public object channel { get; set; }
        public List<History> history { get; set; }
    }

   

