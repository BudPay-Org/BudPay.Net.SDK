using BudPay.Net.SDK.DataTransfers;

namespace BudPay.Net.SDK.Interfaces;

public interface IBudPayClientIntegration
{
    Task<StandardCheckoutResponse> StandardCheckout(StandardCheckoutRequest request, string token);
    Task<InitializeTransactionResponse> InitializeTransaction(InitializeTransactionRequest request, string token);
    Task<BankTransferCheckoutResponse> BankTransferCheckout(BankTransferCheckoutRequest request, string token);
    Task<MomoPaymentProvidersResponse> MomoPaymentProviders(string currency, string token);
    Task<MomoInitiatePaymentResponse> MomoPaymentRequest(MomoInitiatePaymentRequest request, string token);
   Task<InitializeTransactionResponse> V2InitializeTransactionS2S(S2SInitializeTransactionRequest request, string token, string publicKey);
    Task<CreateInvoiceResponse> CreateInvoice(CreateInvoiceRequest request, string token);
    Task<PaymentLinkResponse> GeneratePaymentLink(PaymentLinkRequest request, string token);
    Task<VerifyCollectionTransactionResponse> VerifyTransaction(string reference, string token);
    Task<FetchTransactionResponse> FetchTransactionById(string Id, string token);
    Task<FetchAllTransactionsResponse> FetchAllTransactions(string token);

      #region  Payouts
    Task<BankListResponse> BankList(string token, string? currency = "NGN");
    Task<AccountNumberValidationResponse> AccountNameValidation(string bankCode, string accountNumber, string currency, string token);
    Task<SinglePayoutResponse> SinglePayout(SinglePayoutRequest request, string token, string publicKey);
    Task<BulkPayoutResponse> BulkPayout(BulkPayoutRequest request, string token, string publicKey);
    Task<VerifyPayoutResponse> VerifyPayout(string reference, string token);
    Task<ListAllPayoutResponse> ListAllPayouts(string token);
    Task<PayoutFeeResponse> PayoutFee(string currency, string amount, string token);
    Task<WalletBalanceResponse>WalletBalance(string currency, string token);
    Task<WalletTransactionResponse> WalletTransactions(string currency, string token);


    #endregion Payouts


    #region  BillPayments
      Task<AirtimeProvderResponse> GetAirtimeProviders(string token);
      Task<AirtimeTopupResponse> AirtimeTopup(AirtimeTopupRequest request, string publicKey);
      Task<InternetProviderResponse> GetInternetProviders(string token);
      Task<InternetDataPlansResponse> InternetDataPlans(string provider, string token);
      Task<InternetDataPurchaseResponse> InternetDataPurchase(InternetDataPurchaseRequest request, string token, string publicKey);
      Task<TvProvidersResponse> GetAllTvProviders(string token);
      Task<TvPackageResponse> TvPackages(string provider, string token);
      Task<TvValidateResponse> TvValidate(string provider, string number, string token);
       Task<TvSubscriptionResponse> TvSubscription(TvSubscriptionRequest request, string token, string publicKey);
      Task<ElectricityProviderResponse> ElectricityProviders(string token);
      Task<ElectricityValidateResponse> ElectricityValidate(string provider, string type, string number, string token);
      Task<ElectricityRechargeResponse> ElectricityRecharge(ElectricityRechargeRequest request, string token, string publicKey);


    #endregion BillPayments
}
