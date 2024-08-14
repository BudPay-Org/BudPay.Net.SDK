namespace BudPay.Net.SDK.DataTransfers;

public class FetchAllTransactionsResponse
{
        public bool status { get; set; }
        public string message { get; set; }
        public List<TransactionsResponseDatum> data { get; set; }
        public int total_count { get; set; }
}

    public class TransactionsResponseCustomer
    {
        public int id { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public string email { get; set; }
        public object phone { get; set; }
        public string customer_code { get; set; }
        public string domain { get; set; }
        public string metadata { get; set; }
        public string status { get; set; }
    }

    public class TransactionsResponseDatum
    {
        public int id { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string reference { get; set; }
        public object ip_address { get; set; }
        public string channel { get; set; }
        public string domain { get; set; }
        public object fees { get; set; }
        public object plan { get; set; }
        public string requested_amount { get; set; }
        public string status { get; set; }
        public string gateway { get; set; }
        public DateTime created_at { get; set; }
        public string paid_at { get; set; }
        public Customer customer { get; set; }
    }

   

