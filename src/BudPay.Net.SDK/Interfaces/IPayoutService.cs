using BudPay.Net.SDK.DataTransfers;

namespace BudPay.Net.SDK.Interfaces;

public interface IPayoutService
{
    Task<BankListResponse> BankListAsync(string? currency = "NGN");
    Task<AccountNumberValidationResponse> AccountNameValidation(string bankCode, string accountNumber, string currency);
    Task<SinglePayoutResponse> SinglePayout(SinglePayoutRequest request);
    Task<BulkPayoutResponse> BulkPayout(BulkPayoutRequest request);
    Task< VerifyPayoutResponse> VerifyPayout(string reference);
    Task<ListAllPayoutResponse> ListAllPayouts();
    Task<PayoutFeeResponse> PayoutFee(string currency, string amount);
    Task< WalletBalanceResponse> WalletBalance(string currency);
    Task<WalletTransactionResponse> WalletTransactions(string currency);
}
