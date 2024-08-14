namespace BudPay.Net.SDK.Constants;

public class BaseConstant
{
    public const string BudpayBaseUrl  =  "https://api.budpay.com/api";
    public const string StandardCheckout = "/v2/transaction/initialize";
    public const string InitializeTransactionS2S = "/s2s/transaction/initialize";
    public const string BankTransferCheckout = "/s2s/banktransfer/initialize";
    public const string MomoPaymentProviders = "/s2s/v2/momo/providers/";
    public const string MonoPaymentRequest = "/s2s/v2/momo/payment_request";
    public const string CreateInvoice = "/v2/create_invoice";
    public const string GeneratePaymentLink = "/v2/create_payment_link";
    public const string VerifyTransaction = "/v2/transaction/verify/:";
    public const string FetchTransaction = "/v2/transaction/:";
    public const string FetchAllTransactions = "/v2/transaction";
    
}
