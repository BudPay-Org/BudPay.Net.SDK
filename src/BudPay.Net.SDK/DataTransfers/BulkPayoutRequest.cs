namespace BudPay.Net.SDK.DataTransfers;

public class BulkPayoutRequest
{
   public string currency { get; set; } = "NGN";
  public List<BankTransfer> transfers { get; set; }
}

public class BankTransfer
{
    public string amount { get; set; }
    public string bank_code { get; set; }
    public string bank_name { get; set; }
    public string account_number { get; set; }
    public string narration { get; set; }
}
