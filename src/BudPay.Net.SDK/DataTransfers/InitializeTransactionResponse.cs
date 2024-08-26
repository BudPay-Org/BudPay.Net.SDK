namespace BudPay.Net.SDK.DataTransfers;

public class InitializeTransactionResponse
{
     public bool status { get; set; }
     public string message { get; set; }
     public string? data { get; set; }
     public TransactionLinks? _links { get; set; }
}

    public class TransactionLinks
    {
        public string? url { get; set; }
        public string? method { get; set; }
        public List<string>? payload { get; set; }
    }

  
