namespace BudPay.Net.SDK.DataTransfers;

public class MomoPaymentCallbackResponse
{
        public string status { get; set; }
        public string @event { get; set; }
        public string channel { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string fee { get; set; }
        public string requested_amount { get; set; }
        public string type { get; set; }
        public string reference { get; set; }
        public string phone { get; set; }
        public string PaymentGateway { get; set; }
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public string domain { get; set; }
        public string timestamp { get; set; }
        
}
