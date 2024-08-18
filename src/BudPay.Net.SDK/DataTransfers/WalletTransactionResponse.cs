namespace BudPay.Net.SDK.DataTransfers;

public class WalletTransactionResponse
{
     public bool status { get; set; }
    public string message { get; set; }
    public TransactionsResponse data { get; set; }
}

    public class TransactionsResponse
    {
        public int current_page { get; set; }
        public List<TransactionsResponse> data { get; set; }
        public string first_page_url { get; set; }
        public int from { get; set; }
        public int last_page { get; set; }
        public string last_page_url { get; set; }
        public List<TransactionsLink> links { get; set; }
        public string next_page_url { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public object prev_page_url { get; set; }
        public int to { get; set; }
        public int total { get; set; }
        public int id { get; set; }
        public int wallet_id { get; set; }
        public string type { get; set; }
        public string debit { get; set; }
        public string currency { get; set; }
        public string domain { get; set; }
        public string amount { get; set; }
        public string note { get; set; }
        public string bal_before { get; set; }
        public string bal_after { get; set; }
        public string status { get; set; }
        public string reference { get; set; }
        public DateTime created_at { get; set; }
    }

    public class TransactionsLink
    {
        public string url { get; set; }
        public string label { get; set; }
        public bool active { get; set; }
    }



