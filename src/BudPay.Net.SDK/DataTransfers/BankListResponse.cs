namespace BudPay.Net.SDK.DataTransfers;

public class BankListResponse
{
    public bool success { get; set; }
    public string message { get; set; }
    public string currency { get; set; }
    public List<Bankdata> data { get; set; }
}

    public class Bankdata
    {
        public string bank_name { get; set; }
        public string bank_code { get; set; }
        public string? logo { get; set; }
    }

  

