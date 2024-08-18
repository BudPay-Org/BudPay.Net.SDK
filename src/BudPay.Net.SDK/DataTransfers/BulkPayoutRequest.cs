namespace BudPay.Net.SDK.DataTransfers;

public class BulkPayoutRequest
{
   public string Currency { get; set; } = "NGN";
  public List<BankTransfer> Transfers { get; set; }
}

public class BankTransfer
{
    public string Amount { get; set; }
    public string BankCode { get; set; }
    public string BankName { get; set; }
    public string AccountNumber { get; set; }
    public string Narration { get; set; }
}
