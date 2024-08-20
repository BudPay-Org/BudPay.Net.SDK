using BudPay.Net.SDK.DataTransfers;

namespace BudPay.Net.SDK.Interfaces;

public interface IBudPayClientIntegration
{
    Task<StandardCheckoutResponse> StandardCheckout(StandardCheckoutRequest request, string token);
    Task<string> InitializeTransaction(string cardNumber, string expiryMonth, string expiryYear, string cvv, string pin, 
    string amount, string callback, string currency, string email, string reference,  byte[] key, byte[] iv, string token);
    Task<BankTransferCheckoutResponse> BankTransferCheckout(BankTransferCheckoutRequest request, string token);
    Task<string> MomoPaymentProviders(string currency, string token);
    Task<string> MomoPaymentRequest(MomoInitiatePaymentRequest request, string token);
    Task<string> V2InitializeTransactionS2S(S2SInitializeTransactionRequest request, string token);
    Task<CreateInvoiceResponse> CreateInvoice(CreateInvoiceRequest request, string token);
    Task<VerifyCollectionTransactionResponse> VerifyTransaction(string reference, string token);
    Task<FetchTransactionResponse> FetchTransactionById(string Id, string token);
    Task<FetchAllTransactionsResponse> FetchAllTransactions(string token);

      #region  Payouts
    Task<BankListResponse> BankList(string token, string? currency = "NGN");
    Task<AccountNumberValidationResponse> AccountNameValidation(string bankCode, string accountNumber, string currency, string token);
    Task<SinglePayoutResponse> SinglePayout(SinglePayoutRequest request, string token);
    Task<BulkPayoutResponse> BulkPayout(BulkPayoutRequest request, string token);
    Task<VerifyPayoutResponse> VerifyPayout(string reference, string token);
    Task<ListAllPayoutResponse> ListAllPayouts(string token);
    Task<PayoutFeeResponse> PayoutFee(string currency, string amount, string token);
    Task<WalletBalanceResponse>WalletBalance(string currency, string token);
    Task<WalletTransactionResponse> WalletTransactions(string currency, string token);


    #endregion Payouts


    #region  BillPayments
      Task<AirtimeProvderResponse> GetAirtimeProviders(string token);
      Task<AirtimeTopupResponse> AirtimeTopup(AirtimeTopupRequest request, string token);
      Task<InternetProviderResponse> GetInternetProviders(string token);
      Task<InternetDataPlansResponse> InternetDataPlans(string provider, string token);
      Task<InternetDataPurchaseResponse> InternetDataPurchase(InternetDataPurchaseRequest request, string token);
      Task<TvProvidersResponse> GetAllTvProviders(string token);
      Task<TvPackageResponse> TvPackages(string provider, string token);
      Task<TvValidateResponse> TvValidate(string provider, string number, string token);
      Task<TvSubscriptionResponse> TvSubscription(string provider, string number, string code, string reference, string token);
      Task<ElectricityProviderResponse> ElectricityProviders(string token);
      Task<ElectricityValidateResponse> ElectricityValidate(string provider, string type, string number, string token);
      Task<ElectricityRechargeResponse> ElectricityRecharge(ElectricityRechargeRequest request, string token);


    #endregion BillPayments
}
