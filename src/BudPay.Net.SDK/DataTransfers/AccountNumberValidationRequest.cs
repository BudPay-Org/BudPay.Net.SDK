namespace BudPay.Net.SDK.DataTransfers;

public class AccountNumberValidationRequest
{
   public string bank_code { get; set; }
   public string account_number { get; set; }
   public string currency { get; set; }
}
