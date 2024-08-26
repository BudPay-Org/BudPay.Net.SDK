using BudPay.Net.SDK.DataTransfers;

namespace BudPay.Net.SDK.Interfaces;

public interface IAcceptPaymentService
{
     Task<StandardCheckoutResponse> StandardCheckoutAsync(StandardCheckoutRequest request);
     Task<InitializeTransactionResponse> InitializeTransactionAsync(InitializeTransactionRequest request);
    Task<BankTransferCheckoutResponse> BankTransferCheckoutAsync(BankTransferCheckoutRequest request);
    Task<string> MomoPaymentProvidersAsync(string currency);
     Task<string> MomoPaymentRequestAsync(MomoInitiatePaymentRequest request);
     Task<InitializeTransactionResponse> V2InitializeTransactionS2S(S2SInitializeTransactionRequest request);
     Task<CreateInvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request);
     Task<VerifyCollectionTransactionResponse> VerifyTransactionAsync(string reference);
     Task<FetchTransactionResponse> FetchTransactionByIdAsync(string Id);
     Task<FetchAllTransactionsResponse> FetchAllTransactionsAsync();

}
