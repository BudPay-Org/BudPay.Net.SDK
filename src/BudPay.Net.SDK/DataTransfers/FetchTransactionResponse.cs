namespace BudPay.Net.SDK.DataTransfers;

public class FetchTransactionResponse
{
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
        public Log log { get; set; }
        public object fees { get; set; }
        public Customer customer { get; set; }
        public object plan { get; set; }
        public string paid_at { get; set; }
        public DateTime created_at { get; set; }
        public string requested_amount { get; set; }
}

    public class Customer
    {
        public int id { get; set; }
        public string customer_code { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public object phone { get; set; }
        public string metadata { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string domain { get; set; }
        public string status { get; set; }
        public string reference { get; set; }
        public string amount { get; set; }
        public object gateway_response { get; set; }
        public string paid_at { get; set; }
        public DateTime created_at { get; set; }
        public string channel { get; set; }
        public string currency { get; set; }
        public string ip_address { get; set; }
    }

    public class TransactionResponseHistory
    {
        public string type { get; set; }
        public string message { get; set; }
        public int time { get; set; }
    }

    public class Log
    {
        public int time_spent { get; set; }
        public int attempts { get; set; }
        public object authentication { get; set; }
        public int errors { get; set; }
        public bool success { get; set; }
        public string channel { get; set; }
        public List<TransactionResponseHistory> history { get; set; }
    }



