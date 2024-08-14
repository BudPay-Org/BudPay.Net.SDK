namespace BudPay.Net.SDK.DataTransfers;

public class BankTransferCheckoutResponse
{
      public bool status { get; set; }
        public string message { get; set; }
        public CheckoutResponseData data { get; set; }
}
    public class CheckoutResponseData
    {
        public string account_name { get; set; }
        public string account_number { get; set; }
        public string bank_name { get; set; }
    }

  

