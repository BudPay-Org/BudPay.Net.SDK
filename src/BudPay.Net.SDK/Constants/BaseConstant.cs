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
    public const string GetBanks = "/v2/bank_list";
    public const string AccountNameValidation = "v2/account_name_verify";
    public const string SinglePayout = "/v2/bank_transfer";
    public const string BulkPayout = "/v2/bulk_bank_transfer";
    public const string VerifyPayout = "/v2/payout/:reference";
    public const string ListAllPayouts = "/v2/list_transfers";
    public const string PayoutFee = "/v2/payout_fee";
    public const string WalletBalance = "/v2/wallet_balance/{currency}";
    public const string WalletTransactions = "/v2/wallet_transactions/{currency}";
    
}
