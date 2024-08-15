using BudPay.Net.SDK.DataTransfers;

namespace BudPay.Net.SDK.Interfaces;

public interface IAcceptPaymentService
{
     Task<StandardCheckoutResponse> StandardCheckoutAsync(StandardCheckoutRequest request);
     Task<string> InitializeTransactionAsync(string cardNumber, string expiryMonth, string expiryYear, string cvv, string pin, 
    string amount, string callback, string currency, string email, string reference,  byte[] key, byte[] iv);
    Task<BankTransferCheckoutResponse> BankTransferCheckoutAsync(BankTransferCheckoutRequest request);
    Task<string> MomoPaymentProvidersAsync(string currency);
     Task<string> MomoPaymentRequestAsync(MomoInitiatePaymentRequest request);
     Task<string> V2InitializeTransactionS2S(S2SInitializeTransactionRequest request);
     Task<CreateInvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request);
     Task<VerifyCollectionTransactionResponse> VerifyTransactionAsync(string reference);
     Task<FetchTransactionResponse> FetchTransactionByIdAsync(string Id);
     Task<FetchAllTransactionsResponse> FetchAllTransactionsAsync();

}
